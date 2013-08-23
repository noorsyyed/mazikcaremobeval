using MazikCare.MobEval.RoutingServiceAX;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;
using System.Linq;

namespace MazikCare.MobEval.Datas
{

    public class ServiceHelper
    {

        #region Private Vars
        private MazikCareWebServiceClient _client;
        private ObservableCollection<HMPatientDataContracts> _patients;
        #endregion

        #region CTOR
        public ServiceHelper()
        {
            var binding = new BasicHttpBinding()
            {
                MaxBufferPoolSize = int.MaxValue,
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
            };

            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport = new HttpTransportSecurity()
            {
                ClientCredentialType = HttpClientCredentialType.Ntlm
            };

            var endpoint = new EndpointAddress("http://ax2012-a.contoso.com:85/MicrosoftDynamicsAXAif60/MZKWEB/xppservice.svc");

            this._client = new MazikCareWebServiceClient(binding, endpoint);

            this._client.ClientCredentials.Windows.ClientCredential = new NetworkCredential("Administrator", "pass@word1", "Contoso");

        }
        #endregion

        #region Method Wrappers
        public async Task<ObservableCollection<HMPatientDataContracts>> GetAllProspects()
        {
            if (this._patients == null) //cache the results for better performance
            {
                var settng = ((App)Application.Current).SettingsData;

                var result = await this._client.getAllPatientsAsync();
                var records = result.response;
                var first = (from rec in records where rec.parmMRN.Equals(settng.MRN) select rec).FirstOrDefault();
                var others = from rec in records where !rec.parmMRN.Equals(settng.MRN) select rec;
                this._patients = new ObservableCollection<HMPatientDataContracts>();
                if (first != null)
                {
                    this._patients.Add(first);
                }
                foreach (var rec in others)
                {
                    this._patients.Add(rec);
                } 
            }
            return this._patients;
        }

        public async Task<string> AddDocumentToPrescription(long prescriptionId, StorageFile file)
        {
            using (Stream stream = await file.OpenStreamForReadAsync())
            {
                stream.Position = 0;

                var len = (int)stream.Length;
                byte[] buffer = new byte[len];
                stream.Read(buffer, 0, len);

                var response = await this._client.addNewDocumentAsync(prescriptionId.ToString(), buffer, Path.GetFileNameWithoutExtension(file.Name), Path.GetExtension(file.Name));
                return response.response;
            }
        }

        public async Task<BitmapImage> GetPatientImage(long patientRecId)
        {
            var result = await this._client.getPatientImageAsync(patientRecId.ToString());
            var img = new BitmapImage();

            var mem = new InMemoryRandomAccessStream();
            var writer = new DataWriter(mem);

            writer.WriteBytes(result.response);
            await writer.StoreAsync();

            mem.Seek(0);
            await img.SetSourceAsync(mem);
            return img;
        }

        public async Task<long> CreatePrescription(long patientid, string lon, ObservableCollection<string> itemForOrder, ObservableCollection<string> diagnosis)
        {
            var result = await this._client.createPrescriptionAsync(patientid.ToString(), "5637144826", lon, itemForOrder, diagnosis);
            return long.Parse(result.response); //the recid for the prescription                
        }

        public async Task<bool> ConvertProspectToPatient(long recid)
        {
            var result = await this._client.convertProspectToPatientAsync(recid.ToString());
            return bool.Parse(result.response);
        }
        #endregion

        #region Other Methods
        public HMPatientDataContracts GetPatient()
        {
            return (this._patients != null && this._patients.Count > 0) ? this._patients[0] : new HMPatientDataContracts();
        }
        #endregion
    }
}
