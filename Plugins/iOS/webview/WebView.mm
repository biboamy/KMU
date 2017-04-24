/*
 * Copyright (C) 2011 Keijiro Takahashi
 * Copyright (C) 2012 GREE, Inc.
 *
 * This software is provided 'as-is', without any express or implied
 * warranty.  In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

#import <UIKit/UIKit.h>

extern UIViewController *UnityGetGLViewController();

@interface WebViewPlugin : UIViewController<UIWebViewDelegate>
{
    UIWebView *webView;
    NSString *gameObjectName;
    UINavigationBar *navigationBar;
    UIView *view;
}

@end

@implementation WebViewPlugin

- (id)initWithGameObjectName:(const char *)gameObjectName_
{
    self = [super init];
    view = UnityGetGLViewController().view;
    webView = [[UIWebView alloc] initWithFrame:view.frame];
    webView.delegate = self;
    webView.hidden = YES;
    webView.frame = CGRectMake(0, 50,view.frame.size.width ,view.frame.size.height);
    [view addSubview:webView];
    gameObjectName = [NSString stringWithUTF8String:gameObjectName_];
    
    //initial btn
    [self initNavigationBar];
    
    return self;
}

- (void)dealloc
{
    webView.delegate = nil;
    
    [webView removeFromSuperview];
    [super dealloc];
}

- (void)close
{
    webView.hidden = YES;
    navigationBar.hidden = YES;
}

- (void)initNavigationBar
{
    UINavigationController *addViewControl = [[UINavigationController alloc] init];
    addViewControl.navigationBarHidden = NO;
    addViewControl.view.frame = CGRectMake(0, 0, view.frame.size.width, 50);
    
    navigationBar = [[UINavigationBar alloc] initWithFrame:CGRectMake(0, 0, view.frame.size.width, 50)];
    navigationBar.hidden = NO;
    
    UINavigationItem *title = [[UINavigationItem alloc] initWithTitle:@"cqplayart webview"];
    UIBarButtonItem *back = [[UIBarButtonItem alloc] initWithTitle:@"Back" style:UIBarButtonItemStyleBordered target:self action:@selector(close)];
    title.leftBarButtonItem = back;
    
    navigationBar.items = @[title];
    navigationBar.hidden = YES;
    
    [view addSubview:navigationBar];
}

- (BOOL)webView:(UIWebView *)webViewReturn shouldStartLoadWithRequest:(NSURLRequest *)request navigationType:(UIWebViewNavigationType)navigationType
{
    NSURL* theURL = [request mainDocumentURL];
    NSString* absoluteString = [theURL absoluteString];
    NSString* scene = [[absoluteString componentsSeparatedByString:@"#"] lastObject];
    if ([scene caseInsensitiveCompare:@"scene1"]==0 || [scene caseInsensitiveCompare:@"scene2"]==0)
    {
        const char *name = [scene UTF8String];
        
        UnitySendMessage("MyClass", "getWebViewMsg", name);
        
        [webViewReturn removeFromSuperview];
        webViewReturn = nil;
    }
    
    return YES;
}

- (void)webViewDidStartLoad: (UIWebView*)webView
{
    
    NSString* url = [[[webView request] URL] absoluteString];
    UnitySendMessage( [gameObjectName UTF8String], "onLoadStart", [url UTF8String] );
}

- (void)webViewDidFinishLoad: (UIWebView*)webView
{
    NSString* url = [webView stringByEvaluatingJavaScriptFromString:@"document.URL"];
    UnitySendMessage( [gameObjectName UTF8String], "onLoadFinish", [url UTF8String] );
}
- (void)webViewDidFailLoadWithError: (NSError*)error
{
    [UIApplication sharedApplication].networkActivityIndicatorVisible = NO;
    
    NSInteger err_code = [error code];
    if( err_code == NSURLErrorCancelled )
    {
        return;
    }
}

- (void)setMargins:(int)left top:(int)top right:(int)right bottom:(int)bottom
{
    CGRect frame = view.frame;
    CGFloat scale = view.contentScaleFactor;
    frame.size.width -= (left + right) / scale;
    frame.size.height -= (top + bottom) / scale;
    frame.origin.x += left / scale;
    frame.origin.y += top / scale;
    webView.frame = frame;
}

- (void)setVisibility:(BOOL)visibility
{
    webView.hidden = visibility ? NO : YES;
}

- (void)loadURL:(const char *)url
{
    navigationBar.hidden = NO;
    
    NSString *urlStr = [NSString stringWithUTF8String:url];
    NSURL *nsurl = [NSURL URLWithString:urlStr];
    NSURLRequest *request = [NSURLRequest requestWithURL:nsurl];

    [webView loadRequest:request];
    [webView reload];
    webView.hidden = NO;
}

- (void)evaluateJS:(const char *)js
{
    NSString *jsStr = [NSString stringWithUTF8String:js];
    [webView stringByEvaluatingJavaScriptFromString:jsStr];
}



@end

extern "C" {
    void *_WebViewPlugin_Init(const char *gameObjectName);
    void _WebViewPlugin_Destroy(void *instance);
    void _WebViewPlugin_SetMargins(void *instance, int left, int top, int right, int bottom);
    void _WebViewPlugin_SetVisibility(void *instance, BOOL visibility);
    void _WebViewPlugin_LoadURL(void *instance, const char *url);
    void _WebViewPlugin_EvaluateJS(void *instance, const char *url);
    
    void _externalWebview(const char * url);
}

void *_WebViewPlugin_Init(const char *gameObjectName)
{
    id instance = [[WebViewPlugin alloc] initWithGameObjectName:gameObjectName];
    return (__bridge void *)instance;
}

void _WebViewPlugin_Destroy(void *instance)
{
}

void _WebViewPlugin_SetMargins(void *instance, int left, int top, int right, int bottom)
{
    WebViewPlugin *webViewPlugin = (WebViewPlugin *)instance;
    [webViewPlugin setMargins:left top:top right:right bottom:bottom];
}

void _WebViewPlugin_SetVisibility(void *instance, BOOL visibility)
{
    WebViewPlugin *webViewPlugin = (WebViewPlugin *)instance;
    [webViewPlugin setVisibility:visibility];
}

void _WebViewPlugin_LoadURL(void *instance, const char *url)
{
    NSLog(@"url:%s",url);
    WebViewPlugin *webViewPlugin = (WebViewPlugin *)instance;
    [webViewPlugin loadURL:url];
}

void _WebViewPlugin_EvaluateJS(void *instance, const char *js)
{
    WebViewPlugin *webViewPlugin = (WebViewPlugin *)instance;
    [webViewPlugin evaluateJS:js];
}

void _externalWebview(const char * url)
{
    WebViewPlugin *exWebview = [[WebViewPlugin alloc] init];
    [exWebview externalWebview:url];
}

