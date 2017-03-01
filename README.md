# XamIoc
a very tiny ioc for the xamarin apps and .net standard apps
##Usage
```C#
XamIoc.Bind<IMessenger, Messenger>();
var msg = XamIoc.Resolve<IMessenger>("Love you");
msg.Send();
```
