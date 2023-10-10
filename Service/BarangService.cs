using bwaCrixalis.Shared._1._Master;
using Grpc.Net.Client.Web;
using Grpc.Net.Client;
using Grpc.Core;

namespace LamaranKerjaOnline.Service
{
    public class BarangService
    {
        public IAsyncEnumerable<RplBarangById> GetDataBarang()
        {
            var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
            var channel = GrpcChannel.ForAddress("https://localhost:5022", new GrpcChannelOptions { HttpClient = httpClient });
            var client = new svpMasterBarang.svpMasterBarangClient(channel);
            var request = client.GetBarangStreaming(new RqsBarang());
            return request.ResponseStream.ReadAllAsync();
        }
    }
}
