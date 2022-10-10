using System.Text.Json;

namespace Moneypenny.Data
{
    public class GetEmployees
    {

        public async Task<Employee[]> GetAsync()
        {
            string searchString;
            HttpRequestMessage requestMessage;
            HttpResponseMessage responseMessage;
            HttpClient htp;
            List<Employee> employees;

            htp = new HttpClient();
            requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(@"https://developinterviewstorage.blob.core.windows.net/developinterviewcont/Employees.json")
            };
            responseMessage = await htp.SendAsync(requestMessage);
            employees = JsonSerializer.Deserialize<List<Employee>>(await responseMessage.Content.ReadAsStringAsync());
            return employees.ToArray();
        }
    }
}