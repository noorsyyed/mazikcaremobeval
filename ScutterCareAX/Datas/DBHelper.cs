using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace MazikCare.MobEval.Datas
{
    public class DBHelper
    {
        private SQLiteAsyncConnection _conn;
        private SettingsData _data;
        private PatientPhysicalAssessment _physical;
        private PatientHistory _patientHistory;

        public DBHelper()
        {
            this._conn = new SQLiteAsyncConnection("PatientWork");
        }

        public async Task<PatientPhysicalAssessment> LoadPhysicalData()
        {
            await this._conn.CreateTableAsync<PatientPhysicalAssessment>();
            this._physical = await this._conn.Table<PatientPhysicalAssessment>().FirstOrDefaultAsync() ?? PatientPhysicalAssessment.LoadDefault();
            return this._physical;
        }

        public async Task<PatientHistory> LoadPatientHistory()
        {
            await this._conn.CreateTableAsync<PatientHistory>();
            this._patientHistory = await this._conn.Table<PatientHistory>().FirstOrDefaultAsync() ?? PatientHistory.LoadDefault();
            return this._patientHistory;
        }

        public async Task<SettingsData> LoadData()
        {
            await this._conn.CreateTableAsync<SettingsData>();
            this._data = await this._conn.Table<SettingsData>().FirstOrDefaultAsync() ?? SettingsData.LoadDefault();
            return this._data;
        }

        public async Task SetupData()
        {
            await this._conn.CreateTableAsync<Patient>();

        }

        public static async Task<Stream> GetResourceStreamAsync(string path)
        {
            StorageFile file = await Package.Current.InstalledLocation.GetFileAsync(path);
            Stream stream1;

            using (Stream stream = await file.OpenStreamForReadAsync())
            {
                stream.Position = 0;

                byte[] buffer = new byte[(int)stream.Length];

                stream.Read(buffer, 0, (int)stream.Length);

                stream1 = new MemoryStream(buffer);
            }
            return stream1;
        }

        public async void SaveData(SettingsData data)
        {
            await this._conn.DeleteAsync(data);
            await this._conn.InsertAsync(data);
        }

        public async void SaveData(PatientPhysicalAssessment data)
        {
            await this._conn.DeleteAsync(data);
            await this._conn.InsertAsync(data);
        }

        public async void SaveData(PatientHistory data)
        {
            await this._conn.DeleteAsync(data);
            await this._conn.InsertAsync(data);
        }
    }
}
