##使用Charles在iOS6上进行抓包

###http
我用的是Mac电脑，首先建立一个热点，然后让iOS设备脸上这个热点，并且把Mac电脑的IP设置为代理。这时候，访问网络的时候，Charles会弹出一个选项，只要点击允许就可以。
###https
* 首先要在Charles菜单里面选择安装证书，然后在Charles的代理设置里面，把Enable SSL Proxying前面的选项勾上。接下来iOS设备通过Safari访问http://charlesproxy.com/charles.crt 安装这个证书。做完这些一般的https请求都可以抓取了。
* 有些APP在代码里面进行了https的证书验证，需要把证书验证给去掉。如果你的iOS设备没有破解，那就无能为力了。如果你想继续抓包，就需要破解iOS设备，然后去装一个iOS SSL Kill的Cydia插件。这个插件是开源的，Github上有，网址是https://github.com/iSECPartners/ios-ssl-kill-switch。做到这些，基本上可以分析iOS上任意APP的网络协议了。<http://www.ravelrumba.com/blog/ipad-http-debugging/>