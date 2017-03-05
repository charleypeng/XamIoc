# XamIoc
a very tiny ioc for the xamarin apps and .net standard apps
##Usage
```C#
public interface IMessenger
{
  void Send();
}
public class Messenger:IMessenger
{
  public Messenger(string msg)
  {
    ...
  }
  public void Send()
  {
    ...
  }
}

public class App
{
  public App()
  {
    //wire the interface and implementation
    XamIoc.Core.Bind<IMessenger, Messenger>();
    //resolve the interface and passing a parameter
    var msg = XamIoc.Core.Resolve<IMessenger>("Love you");
    msg.Send();
  }
}

```
