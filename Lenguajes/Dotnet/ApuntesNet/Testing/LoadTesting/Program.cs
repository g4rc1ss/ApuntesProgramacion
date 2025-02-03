using var httpclient = new HttpClient();
var http = "http";
var url = "localhost";
var port = "5031";
// var path = "normalRequest";
// var path = "nonBlockRequest";
var path = "blockRequest";

Parallel.For(0, Int32.MaxValue, i =>
{
    var response = httpclient.GetAsync($"{http}://{url}:{port}/{path}");
    response.Wait();
    Console.WriteLine(response.Result.StatusCode);
});