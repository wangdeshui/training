
# 升级xcode5.1 编译问题
###目前ios的指令集有以下几种：

* armv6
* iPhone
* iPhone2
* iPhone3G
* 第一代和第二代iPod Touch

####armv7
	* iPhone4
	* iPhone4S
####armv7s
	* iPhone5
	* iPhone5C
#### arm64
	* iPhone5S
 
 机器对指令集的支持是向下兼容的，因此armv7的指令集是可以运行在iphone5S的，只是效率没那么高而已~

 
	Architecture ： 指你想支持的指令集。

	Valid architectures : 指即将编译的指令集。

	Build Active Architecture Only : 只是否只编译当前适用的指令集。

 

PS:选arm64时需要最低支持5.1.1:

xcode5.1编译Failed xcode5.1默认的编译64bit（arm64） 某些静态库暂不支持64bit

### 编译出错时
1. Product--Clean
2. change standard to below
	[build](https://github.com/wangdeshui/wiki-images/raw/master/xcode5.1-build-issue.png)
3. 如果还不行 set build active architecture only to No 