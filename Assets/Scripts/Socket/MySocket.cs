using socket.io;

public class MySocket{
    private static Socket socket;
    private static string url = "http://ec2-52-78-8-84.ap-northeast-2.compute.amazonaws.com:3000/";

    public static Socket getInstance()
    {
        if(socket == null)
        {
            socket = Socket.Connect(url);
        }

        return socket;
    }
}
