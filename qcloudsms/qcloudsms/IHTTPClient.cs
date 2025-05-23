namespace qcloudsms
{

    public interface IHTTPClient
    {
        HTTPResponse fetch(HTTPRequest request);

        void close();
    }
}