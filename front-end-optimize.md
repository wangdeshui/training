# Web application performance
## Minimize HTTP Requests
* Combined files
* CSS Sprites 
Reducing the number of HTTP requests in your page is the place to start. This is the most important guideline for improving performance for first time visitors

## Use a Content Delivery Network
	
	when you use CDN, please use // instead of http or https such as //google.com/cdn/jquery.js
	

## Add an Expires or a Cache-Control Header
* For static components: implement "Never expire" policy by setting far future Expires header
* For dynamic components: use an appropriate Cache-Control header to help the browser with conditional requests

Browsers (and proxies) use a cache to reduce the number and size of HTTP requests, making web pages load faster. A web server uses the Expires header in the HTTP response to tell the client how long a component can be cached. This is a far future Expires header, telling the browser that this response won't be stale until April 15, 2010.
      
      Expires: Thu, 15 Apr 2010 20:00:00 GMT
      
      
   
## Gzip Components
Starting with HTTP/1.1, web clients indicate support for compression with the Accept-Encoding header in the HTTP request.
      
      Accept-Encoding: gzip, deflate

If the web server sees this header in the request, it may compress the response using one of the methods listed by the client. The web server notifies the web client of this via the Content-Encoding header in the response.
      
      Content-Encoding: gzip
      
      
## Put Stylesheets at the Top
Moving stylesheets to the document HEAD makes pages appear to be loading faster. This is because putting stylesheets in the HEAD allows the page to render progressively.


##Put Scripts at the Bottom
The problem caused by scripts is that they block parallel downloads. The HTTP/1.1 specification suggests that browsers download no more than two components in parallel per hostname. If you serve your images from multiple hostnames, you can get more than two downloads to occur in parallel. While a script is downloading, however, the browser won't start any other downloads, even on different hostnames.

An alternative suggestion that often comes up is to use deferred scripts. The DEFER attribute indicates that the script does not contain document.write, and is a clue to browsers that they can continue rendering. Unfortunately, Firefox doesn't support the DEFER attribute. In Internet Explorer, the script may be deferred, but not as much as desired. If a script can be deferred, it can also be moved to the bottom of the page. That will make your web pages load faster.

## Avoid CSS Expressions
CSS expressions are a powerful (and dangerous) way to set CSS properties dynamically. They were supported in Internet Explorer starting with version 5, but were deprecated starting with IE8. As an example, the background color could be set to alternate every hour using CSS expressions:
      
      background-color: expression( (new Date()).getHours()%2 ? "#B8D4FF" : "#F08A00" );

As shown here, the expression method accepts a JavaScript expression. The CSS property is set to the result of evaluating the JavaScript expression. The expression method is ignored by other browsers, so it is useful for setting properties in Internet Explorer needed to create a consistent experience across browsers.
The problem with expressions is that they are evaluated more frequently than most people expect. Not only are they evaluated when the page is rendered and resized, but also when the page is scrolled and even when the user moves the mouse over the page. Adding a counter to the CSS expression allows us to keep track of when and how often a CSS expression is evaluated. Moving the mouse around the page can easily generate more than 10,000 evaluations.

## Make JavaScript and CSS External
Using external files in the real world generally produces faster pages because the JavaScript and CSS files are cached by the browser. JavaScript and CSS that are inlined in HTML documents get downloaded every time the HTML document is requested. This reduces the number of HTTP requests that are needed, but increases the size of the HTML document. On the other hand, if the JavaScript and CSS are in external files cached by the browser, the size of the HTML document is reduced without increasing the number of HTTP requests.

If users on your site have multiple page views per session and many of your pages re-use the same scripts and stylesheets, there is a greater potential benefit from cached external files.

## Reduce DNS Lookups

The Domain Name System (DNS) maps hostnames to IP addresses, just as phonebooks map people's names to their phone numbers. When you type www.yahoo.com into your browser, a DNS resolver contacted by the browser returns that server's IP address. DNS has a cost. **It typically takes 20-120 milliseconds for DNS to lookup the IP address for a given hostname. The browser can't download anything from this hostname until the DNS lookup is completed**.

## Minify JavaScript and CSS
Minification is the practice of removing unnecessary characters from code to reduce its size thereby improving load times. When code is minified all comments are removed, as well as unneeded white space characters (space, newline, and tab). In the case of JavaScript, this improves response time performance because the size of the downloaded file is reduced. Two popular tools for minifying JavaScript code are **JSMin and YUI Compressor**. The YUI compressor can also minify CSS.

## Avoid Redirects
Redirects are accomplished using the 301 and 302 status codes. Here's an example of the HTTP headers in a 301 response:
      
      HTTP/1.1 301 Moved Permanently
      Location: http://example.com/newuri
      Content-Type: text/html
      
      
## Remove Duplicate Scripts
Unnecessary HTTP requests happen in Internet Explorer, but not in Firefox. In Internet Explorer, if an external script is included twice and is not cacheable, it generates two HTTP requests during page loading. Even if the script is cacheable, extra HTTP requests occur when the user reloads the page.


## Configure ETags
Entity tags (ETags) are a mechanism that web servers and browsers use to determine whether the component in the browser's cache matches the one on the origin server.
 The origin server specifies the component's ETag using the ETag response header.
     
      HTTP/1.1 200 OK
      Last-Modified: Tue, 12 Dec 2006 03:03:59 GMT
      ETag: "10c24bc-4ab-457e1c1f"
      Content-Length: 12195

Later, if the browser has to validate a component, it uses the If-None-Match header to pass the ETag back to the origin server. If the ETags match, a 304 status code is returned reducing the response by 12195 bytes for this example.
      
      GET /i/yahoo.gif HTTP/1.1
      Host: us.yimg.com
      If-Modified-Since: Tue, 12 Dec 2006 03:03:59 GMT
      If-None-Match: "10c24bc-4ab-457e1c1f"
      HTTP/1.1 304 Not Modified
## Make Ajax Cacheable
**"asynchronous" does not imply "instantaneous".**
To improve performance, it's important to optimize these Ajax responses. The most important way to improve the performance of Ajax is to make the responses cacheable, as discussed in Add an Expires or a Cache-Control Header. Some of the other rules also apply to Ajax:
* Gzip Components
* Reduce DNS Lookups
* Minify JavaScript
* Avoid Redirects
* Configure ETags


## Use GET for AJAX Requests
when using XMLHttpRequest, POST is implemented in the browsers as a two-step process: sending the headers first, then sending data. So it's best to use GET, which only takes one TCP packet to send (unless you have a lot of cookies). The maximum URL length in IE is 2K, so if you send more than 2K data you might not be able to use GET.
An interesting side affect is that POST without actually posting any data behaves like GET. Based on the HTTP specs, GET is meant for retrieving information, so it makes sense (semantically) to use GET when you're only requesting data, as opposed to sending data to be stored server-side.

## Post-load Components

## Preload Components

## Reduce the Number of DOM Elements
for example use <div>s only when it makes sense semantically, and not because it renders a new line.
##Split Components Across Domains
Splitting components allows you to maximize parallel downloads. Make sure you're using not more than 2-4 domains because of the DNS lookup penalty. For example, you can host your HTML and dynamic content on www.example.org and split static components between static1.example.org and static2.example.org

## Minimize the Number of iframes
Iframes allow an HTML document to be inserted in the parent document. It's important to understand how iframes work so they can be used effectively.

* pros:
	
	1）Helps with slow third-party content like badges and ads
	
	2）Security sandbox
	
	3）Download scripts in parallel

* cons:
	
	1）Costly even if blank
	
	2） Blocks page onload
	
	3） Non-semantic

## No 404s
HTTP requests are expensive so making an HTTP request and getting a useless response (i.e. 404 Not Found) is totally unnecessary and will slow down the user experience without any benefit.

## Reduce Cookie Size
HTTP cookies are used for a variety of reasons such as authentication and personalization. Information about cookies is exchanged in the HTTP headers between web servers and browsers. It's important to keep the size of cookies as low as possible to minimize the impact on the user's response time.

* Eliminate unnecessary cookies
* Keep cookie sizes as low as possible to minimize the impact on the user response time
* Be mindful of setting cookies at the appropriate domain level so other sub-domains are not affected
* Set an Expires date appropriately. An earlier Expires date or none removes the cookie sooner, improving the user response time

## Use Cookie-free Domains for Components
When the browser makes a request for a static image and sends cookies together with the request, the server doesn't have any use for those cookies. So they only create network traffic for no good reason. You should make sure static components are requested with cookie-free requests. Create a subdomain and host all your static components there.
If your domain is www.example.org, you can host your static components on static.example.org. However, if you've already set cookies on the top-level domain example.org as opposed to www.example.org, then all the requests to static.example.org will include those cookies. In this case, you can buy a whole new domain, host your static components there, and keep this domain cookie-free.

## Minimize DOM Access
Accessing DOM elements with JavaScript is slow so in order to have a more responsive page, you should:
* Cache references to accessed elements
* Update nodes "offline" and then add them to the tree
* Avoid fixing layout with JavaScript

## Don't Scale Images in HTML

##Make favicon.ico Small and Cacheable
The favicon.ico is an image that stays in the root of your server. It's a necessary evil because even if you don't care about it the browser will still request it, so it's better not to respond with a 404 Not Found. Also since it's on the same server, cookies are sent every time it's requested. This image also interferes with the download sequence

So to mitigate the drawbacks of having a favicon.ico make sure:
* It's small, preferably under 1K.
* Set Expires header with what you feel comfortable (since you cannot rename it if you decide to change it). You can probably safely set the Expires header a few months in the future. You can check the last modified date of your current favicon.ico to make an informed decision.

## Keep Components under 25K
This restriction is related to the fact that iPhone won't cache components bigger than 25K. Note that this is the uncompressed size. This is where minification is important because gzip alone may not be sufficient.

## Avoid Empty Image src
	straight HTML
	<img src="">
	JavaScript
	
	var img = new Image();
	img.src = "";
	
	

Samples:

<https://github.com/wangdeshui/front-end-work-flow-samples>	