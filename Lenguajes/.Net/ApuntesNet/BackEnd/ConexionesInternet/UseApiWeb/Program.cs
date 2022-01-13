using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

var client = new HttpClient();
var yearList = Enumerable.Range(2015, 7);
var daysList = Enumerable.Range(1, 25);
var current = Directory.GetCurrentDirectory();


await Parallel.ForEachAsync(yearList, async (year, token) =>
{
    Directory.CreateDirectory(current + $"/{year}");
    await Parallel.ForEachAsync(daysList, async (day, token) =>
    {
        var response = await client.GetStringAsync($"https://adventofcode.com/{year}/day/{day}", token);
        Directory.CreateDirectory(current + $"/{year}/{day}");
        await File.WriteAllTextAsync(current + $"/{year}/{day}/enunciado.md", response);
    });
});
