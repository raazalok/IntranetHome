/**
 * User: silentium
 * Date: 22.08.12
 * Time: 13:25
 */
function getInternetExplorerVersion() {
	var rv = -1; // Return value assumes failure.
	if (navigator.appName == 'Microsoft Internet Explorer')
	{
		var ua = navigator.userAgent;
		var re  = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
		if (re.exec(ua) != null)
			rv = parseFloat( RegExp.$1 );
	}
	return rv;
}
function __parseBorderWidth(width) {
	var res = 0;
	if (typeof(width) == "string" && width != null && width != "" ) {
		var p = width.indexOf("px");
		if (p >= 0) {
			res = parseInt(width.substring(0, p));
		}
		else {
			//do not know how to calculate other values (such as 0.5em or 0.1cm) correctly now
			//so just set the width to 1 pixel
			res = 1;
		}
	}
	return res;
}

//returns border width for some element
function __getBorderWidth(element) {
	var res = {left:0,top:0,bottom:0,right:0};
	if (window.getComputedStyle) {
		//for Firefox
		var elStyle = window.getComputedStyle(element, null);
		res.left = parseInt(elStyle.borderLeftWidth.slice(0, -2));
		res.top = parseInt(elStyle.borderTopWidth.slice(0, -2));
		res.right = parseInt(elStyle.borderRightWidth.slice(0, -2));
		res.bottom = parseInt(elStyle.borderBottomWidth.slice(0, -2));
	}
	else {
		//for other browsers
		res.left = __parseBorderWidth(element.style.borderLeftWidth);
		res.top = __parseBorderWidth(element.style.borderTopWidth);
		res.right = __parseBorderWidth(element.style.borderRightWidth);
		res.bottom = __parseBorderWidth(element.style.borderBottomWidth);
	}
	return res;
}
function getxy(element) {
	var res = {pageX:0,pageY:0};
	if (element !== null) {
		res.pageX = element.offsetLeft;

		var offsetParent = element.offsetParent;
		var borderWidth = null;

		while (offsetParent != null) {
			res.pageX += offsetParent.offsetLeft;
			res.pageY += offsetParent.offsetTop;

			borderWidth = __getBorderWidth(offsetParent);
			res.pageX += borderWidth.left;
			res.pageY += borderWidth.top;

			if (offsetParent != document.body && offsetParent != document.documentElement) {
				res.pageX -= offsetParent.scrollLeft;
				res.pageY -= offsetParent.scrollTop;
			}

			offsetParent = offsetParent.offsetParent;
		}
	}
	return res;
}
ie = getInternetExplorerVersion();

if( typeof document.getElementsByClassName != 'function' ) {
	document.getElementsByClassName /*= Element.prototype.getElementsByClassName*/ = function (className) {
		if( !className )
			return [];
		var elements = this.getElementsByTagName('*');
		var list = [];
		var expr = new RegExp( '(^|\\b)' + className + '(\\b|$)' );
		for (var i = 0, length = elements.length; i < length; i++) {
			var clss = elements[i].className.split(' ');
			if (clss.indexOf(className)>-1)
				list.push(elements[i]);
		}
		return list;
	};
}
if(!Array.indexOf){
	Array.prototype.indexOf = function(obj){
		for(var i=0; i<this.length; i++){
			if(this[i]==obj){
				return i;
			}
		}
		return -1;
	}
}


if (typeof Event == 'undefined') Event = new Object();

/*
 * Registers function +fn+ will be executed when the dom
 * tree is loaded without waiting for images.
 *
 * Example:
 *
 * Event.domReady.add(function() {
 * ...
 * });
 *
 */
Event.domReady = {
	add: function(fn) {

//-----------------------------------------------------------
// Already loaded?
//-----------------------------------------------------------
		if (Event.domReady.loaded) return fn();

//-----------------------------------------------------------
// Observers
//-----------------------------------------------------------
		var observers = Event.domReady.observers;
		if (!observers) observers = Event.domReady.observers = [];
// Array#push is not supported by Mac IE 5
		observers[observers.length] = fn;

//-----------------------------------------------------------
// domReady function
//-----------------------------------------------------------
		if (Event.domReady.callback) return;
		Event.domReady.callback = function() {
			if (Event.domReady.loaded) return;

			Event.domReady.loaded = true;
			if (Event.domReady.timer) {
				clearInterval(Event.domReady.timer);
				Event.domReady.timer = null;
			}

			var observers = Event.domReady.observers;
			for (var i = 0, length = observers.length; i < length; i++) {
				var fn = observers[i];
				observers[i] = null;
				fn(); // make 'this' as window
			}
			Event.domReady.callback = Event.domReady.observers = null;
		};

//-----------------------------------------------------------
// Emulates 'onDOMContentLoaded'
//-----------------------------------------------------------
		var ie = !!(window.attachEvent && !window.opera);
		var webkit = navigator.userAgent.indexOf('AppleWebKit/') > -1;

		if (document.readyState && webkit) {

// Apple WebKit (Safari, OmniWeb, ...)
			Event.domReady.timer = setInterval(function() {
				var state = document.readyState;
				if (state == 'loaded' || state == 'complete') {
					Event.domReady.callback();
				}
			}, 50);

		} else if (document.readyState && ie) {

// Windows IE
			var src = (window.location.protocol == 'https:') ? '://0' : 'javascript:void(0)';
			document.write(
					'<script type="text/javascript" defer="defer" src="' + src + '" ' +
							'onreadystatechange="if (this.readyState == \'complete\') Event.domReady.callback();"' +
							'><\/script>');

		} else {

			if (window.addEventListener) {
// for Mozilla browsers, Opera 9
				document.addEventListener("DOMContentLoaded", Event.domReady.callback, false);
// Fail safe
				window.addEventListener("load", Event.domReady.callback, false);
			} else if (window.attachEvent) {
				window.attachEvent('onload', Event.domReady.callback);
			} else {
// Legacy browsers (e.g. Mac IE 5)
				var fn = window.onload;
				window.onload = function() {
					Event.domReady.callback();
					if (fn) fn();
				}
			}

		}

	}
};



if (typeof window.pluso == "undefined") {
	pluso = {version:"0.9", notEmbeded: true};
}
		if (typeof pluso.init != "function") pluso.init = function () {

			var d = document, e = encodeURIComponent, l = d.location;
			this.setCounter(this.counter);

			pluso.screenWidth = null;
			pluso.screenHeight = null;
			if (parseInt(navigator.appVersion)>3) {
				pluso.screenWidth = screen.width;
				pluso.screenHeight = screen.height;
			}
			else if (navigator.appName == "Netscape" && parseInt(navigator.appVersion)==3 && navigator.javaEnabled()) {
				var jToolkit = java.awt.Toolkit.getDefaultToolkit();
				var jScreenSize = jToolkit.getScreenSize();
				pluso.screenWidth = jScreenSize.width;
				pluso.screenHeight = jScreenSize.height;
			}

			var pluso_cont = d.getElementsByClassName('pluso');
			var div = document.createElement('div');
			var a;
			for (var i = 0; i < pluso_cont.length; i++) {
				var p = pluso_cont[i];
//				var numbers = !!(p.className.indexOf('numbers') + 1);

				var links = p.getElementsByTagName('a');

				for (var j = 0; j < links.length; j++) {
					a = links[j];
					var cls = a.className.split(' ');

					for (var k = 0; k < cls.length; k++) {
						if (cls[k].substring(0, 6) == 'pluso-') {
							cls = cls[k];
							break;
						}
					}
					if (typeof cls != "string") continue;
					var type = cls.substring(6);

					a.href = "javascript:void(0)";
					if (cls == "pluso-more") {
						a.onmouseover = function(event){
							if (ie==7||ie==8){
								event = getxy(this);
							}
							pluso.openTimeout = setTimeout(function(){
								pluso.onShowMore(event);
							}, 500);
						};
						a.onmouseout = function(){
							clearTimeout(pluso.openTimeout);
						};
						a.onclick = function(event){
							if (ie==7||ie==8){
								event = getxy(this);
							}
							pluso.onShowMore(event);
						};
						/*	} else if (numbers) {

						 cls = cls.substring(6);
						 if (pluso.codes[cls]) {
						 div.innerHTML = pluso.codes[cls];
						 elem = div.firstChild;
						 a.appendChild(div.firstChild);
						 (function(){
						 var elem = a;
						 pluso.addJS(pluso.scripts[cls], 'pluso-script-'+cls, pluso.handlers[cls]);

						 })();

						 }


						 a.onclick = (function(cls){
						 return function() { alert(type); }
						 })(cls);

						 //						a.parentNode.removeChild(a);
						 //*/
					} else if (cls == "pluso-bookmark" && window.opera) {
						a.setAttribute('rel','sidebar');
						a.title = pluso.titles[type];
						a.href = document.location.href;
						a.onclick = function (){
							this.title = document.title;
						};
					} else {
						a.onclick = pluso.onShareClick(type);
						a.title = pluso.titles[type];
					}


				}
//				while (to_remove.length) {
//					a = to_remove.pop();
//					a.parentNode.removeChild(a);
//				}
			}


		};

		pluso.counter = pluso.counter || 0;

		if (typeof pluso.setCounter != "function") pluso.setCounter = function (c) {
			pluso.counter = c;
			var cntr = document.getElementsByClassName("pluso-counter");
			for (var i in cntr) {
				cntr[i].innerHTML = c;
			}
//			alert(c);
		};

		pluso.updateCounter = function() {
			pluso.addJS("+counter.php?u="+encodeURIComponent(document.location.href)+"&k="+pluso.randomString(16));
		};


		pluso.addJS = function(url, id, callback) {
			if (typeof id == "function") {
				callback = id;
				id = null;
			}

			if (id && document.getElementById(id)) return;
			var h = document.getElementsByTagName('head')[0];
			if (url[0]=="+") {
				url = this.url + url.substring(1);
			}
			s = document.createElement('script');
			s.src = url;
//			if (id) s.id = id;


			if (typeof callback == "function") {
				var called = false;
				s.onreadystatechange = function() {
					if (this.readyState == "complete" && !called) {
						called = true;
						callback();
					}
				};
				s.onload = function() {
					if (!called) {
						called = true;
						callback();
					}
				};
			}

			s.setAttribute('charset', 'UTF-8');
			h.appendChild(s);
		};

		pluso.onShareClick = function(sharer) {
			return function () {
				var d = document, w = window, e = encodeURIComponent, l = d.location;
				var k = d.getSelection, y = w.getSelection, x = d.selection;
				var s = (y ? y() : (k) ? k() : (x ? x.createRange().text : 0));

				var share = pluso["share_"+sharer];
				if (typeof share == "function") {

					pluso.addJS('+ping.php?t='+sharer+'&u=' + e(l.href)
							+ (pluso.screenWidth && pluso.screenHeight ? '&w=' + pluso.screenWidth + '&h='+ pluso.screenHeight : '')
							+ "&ref=" + encodeURIComponent(document.referrer) );
					share();

				} else {

					var sharelink = pluso.url+'share.php?type=' + e(sharer) + '&u=' + e(l.href) + '&t=' + e(d.title) + '&s=' + e(s)
							+ (pluso.screenWidth && pluso.screenHeight ? '&w=' + pluso.screenWidth + '&h='+ pluso.screenHeight : '')
							+ "&ref=" + encodeURIComponent(document.referrer);
//					var op = function () {
					if (!window.open(sharelink, sharer, pluso.tabbed.indexOf(sharer)==-1?'toolbar=0,status=0,resizable=1,width=626,height=436':'')) {
						l.href = sharelink;
					}
					setTimeout(function() {
						pluso.updateCounter();
					}, 1000);
//					};
//					if (/Firefox/.test(navigator.userAgent)) {
//						setTimeout(op, 0);
//					} else {
//						op();
//					}
				}
				return false;
			};
		};

		pluso.closeTimeout = null;
		pluso.openTimeout = null;
		pluso.onShowMore = function (event) {
			var d = document, w = window, e = encodeURIComponent, l = d.location;
			var blocks;
			while ((blocks = d.getElementsByClassName("pluso-box")).length) {
				blocks[0].parentNode.removeChild(blocks[0]);
			}
			pluso.addJS('+ping.php?t=more&u=' + e(l.href)
					+ (pluso.screenWidth && pluso.screenHeight ? '&w=' + pluso.screenWidth + '&h='+ pluso.screenHeight : '')
					+ "&ref=" + encodeURIComponent(document.referrer) );
			var div = document.createElement("div");
			div.className = "pluso-box";
			var x = event.pageX-40;
			var y = event.pageY-40;
			if (this.getWidth()-x < 275) x = this.getWidth() - 275;
			if (this.getHeight()-y < 223) y = this.getHeight() - 223;
			div.style.left = x + "px";
			div.style.top = y + "px";
			div.onmouseout = function() {
				var that = this;
				clearTimeout(pluso.closeTimeout);
				pluso.closeTimeout = setTimeout(function(){
					pluso.closeBox(that);
				}, 1000);
			};
			div.onmouseover = function() {
				clearTimeout(pluso.closeTimeout);
			};
			div.innerHTML = '<div class="pluso-title"><a class="pluso-box-close" href="">x</a><a target="_blank" href="http://share.pluso.ru/?new"><img src="http://share.pluso.ru/img/logo-mini.png" alt="+PLUSO"></a><a class="pluso-box-go" target="_blank" href="http://share.pluso.ru/?new">Получите свои кнопки</a></div>\
									<div class="pluso-scroll"><table><tr>\
			<td><a class="pluso-facebook" href="" title="Facebook"><u></u>Facebook</a></td>\
					<td><a class="pluso-twitter" href="" title="Twitter"><u></u>Twitter</a></td>\
			</tr><tr>							<td><a class="pluso-vkontakte" href="" title="В Контакте"><u></u>В Контакте</a></td>\
				<td><a class="pluso-odnoklassniki" href="" title="Одноклассники"><u></u>Одноклассники</a></td>\
			</tr><tr>							<td><a class="pluso-google" href="" title="Google+"><u></u>Google+</a></td>\
				<td><a class="pluso-livejournal" href="" title="LiveJournal"><u></u>LiveJournal</a></td>\
			</tr><tr>							<td><a class="pluso-moimir" href="" title="Мой Мир@Mail.Ru"><u></u>Мой Мир@Mail.Ru</a></td>\
				<td><a class="pluso-liveinternet" href="" title="LiveInternet"><u></u>LiveInternet</a></td>\
			</tr><tr>							<td><a class="pluso-blogger" href="" title="Blogger"><u></u>Blogger</a></td>\
				<td><a class="pluso-delicious" href="" title="Delicious"><u></u>Delicious</a></td>\
			</tr><tr>							<td><a class="pluso-digg" href="" title="Digg"><u></u>Digg</a></td>\
				<td><a class="pluso-evernote" href="" title="Evernote"><u></u>Evernote</a></td>\
			</tr><tr>							<td><a class="pluso-formspring" href="" title="Formspring.me"><u></u>Formspring.me</a></td>\
				<td><a class="pluso-instapaper" href="" title="Instapaper"><u></u>Instapaper</a></td>\
			</tr><tr>							<td><a class="pluso-myspace" href="" title="mySpace"><u></u>mySpace</a></td>\
				<td><a class="pluso-pinme" href="" title="Pinme"><u></u>Pinme</a></td>\
			</tr><tr>							<td><a class="pluso-pinterest" href="" title="Pinterest"><u></u>Pinterest</a></td>\
				<td><a class="pluso-readability" href="" title="Readability"><u></u>Readability</a></td>\
			</tr><tr>							<td><a class="pluso-springpad" href="" title="Springpad"><u></u>Springpad</a></td>\
				<td><a class="pluso-stumbleupon" href="" title="StumbleUpon"><u></u>StumbleUpon</a></td>\
			</tr><tr>							<td><a class="pluso-surfingbird" href="" title="Surfingbird"><u></u>Surfingbird</a></td>\
				<td><a class="pluso-tumblr" href="" title="Tumblr"><u></u>Tumblr</a></td>\
			</tr><tr>							<td><a class="pluso-yandex" href="" title="Я.ру"><u></u>Я.ру</a></td>\
				<td><a class="pluso-bobrdobr" href="" title="БобрДобр"><u></u>БобрДобр</a></td>\
			</tr><tr>							<td><a class="pluso-vkrugu" href="" title="В Кругу Друзей"><u></u>В Кругу Друзей</a></td>\
				<td><a class="pluso-bookmark" href="" title="В закладки"><u></u>В закладки</a></td>\
			</tr><tr>							<td><a class="pluso-email" href="" title="Отправить на email"><u></u>Отправить на email</a></td>\
				<td><a class="pluso-print" href="" title="Печатать"><u></u>Печатать</a></td>\
										</tr></table></div>';
			var links = div.getElementsByTagName('a');
			for (var i = 0; i < links.length; i++) {
				var a = links[i];
				var cls = a.className.split(' ');
				for (var j = 0; j < cls.length; j++) {
					if (cls[j].substring(0, 6) == 'pluso-') {
						cls = cls[j];
						break;
					}
				}
				if (typeof cls != "string") continue;
				if ( cls == "pluso-box-go" ) {
					//keep link
				} else if (cls == "pluso-box-close" ) {
					a.onclick = function() {
						pluso.closeBox(this.parentNode.parentNode);
						return false;
					};
				} else {
					a.onclick = pluso.onShareClick(cls.substring(6));
				}
			}
			document.getElementsByTagName('body')[0].appendChild(div);
			return false;
		};

		pluso.closeBox = function(em){
			if (typeof em == "object") {
				em.parentNode.removeChild(em);
			}
		};

		pluso.getHeight = function() {
			var body = document.body, html = document.documentElement;
			return Math.max( body.scrollHeight, body.offsetHeight, html.clientHeight, html.scrollHeight, html.offsetHeight );
		};
		pluso.getWidth = function() {
			var body = document.body, html = document.documentElement;
			return Math.max( body.scrollWidth, body.offsetWidth, html.clientWidth, html.scrollWidth, html.offsetWidth );
		};

		pluso.randomString = function(length) {
			var chars = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXTZabcdefghiklmnopqrstuvwxyz'.split('');

			if (! length) {
				length = Math.floor(Math.random() * chars.length);
			}

			var str = '';
			for (var i = 0; i < length; i++) {
				str += chars[Math.floor(Math.random() * chars.length)];
			}
			return str;
		};


		pluso.share_pinterest = function() {
			pluso.addJS('http://assets.pinterest.com/js/pinmarklet.js?r=' + Math.random() * 99999999);
		};

		pluso.share_pinme = function() {
			pluso.addJS('http://st.pinme.ru/js/pinbutton.js?r=' + Math.random() * 99999999);
		};

		pluso.share_readability = function() {
			pluso.addJS('http://www.readability.com/bookmarklet/save.js?r=' + Math.random() * 99999999);
		};

		pluso.share_print = function() {
			window.print();
		};

		pluso.share_bookmark = function() {

			var url = document.location.href;
			var title = document.title;
			if ((typeof window.sidebar == "object") && (typeof window.sidebar.addPanel == "function")) {
				window.sidebar.addPanel (title, url, "");
			} else if (typeof window.external == "object") {
				window.external.AddFavorite(url, title);
			}
		};

		pluso.share_email = function() {
			var link = "mailto:?Subject="+document.title+"&body="+document.location.href+"%0A";
			window.open(link, 'mailto');
		};

		pluso.titles = {
			'facebook':'Facebook',
			'twitter':'Twitter',
			'tumblr':'Tumblr',
			'vkontakte':'В Контакте',
			'odnoklassniki':'Одноклассники',
			'google':'Google+',
			'livejournal':'LiveJournal',
			'moimir':'Мой Мир@Mail.Ru',
			'pinterest':'Pinterest',
			'liveinternet':'LiveInternet',
			'springpad':'Springpad',
			'stumbleupon':'StumbleUpon',
			'myspace':'mySpace',
			'formspring':'Formspring.me',
			'blogger':'Blogger',
			'digg':'Digg',
			'surfingbird':'Surfingbird',
			'bobrdobr':'БобрДобр',
			'readability':'Readability',
			'instapaper':'Instapaper',
			'evernote':'Evernote',
			'delicious':'Delicious',
			'vkrugu':'В Кругу Друзей',
			'pinme':'Pinme',
			'yandex':'Я.ру',
			'bookmark':'В закладки',
			'email':'Отправить на email',
			'print':'Печатать'
		};

		pluso.tabbed = [
			'livejournal',
			'stumbleupon',
			'bobrdobr',
			'evernote',
			'instapaper',
			'digg'
		];

	pluso.url = document.location.href!='http://pluso.test/'?'http://share.pluso.ru/':'http://pluso.test/';
	pluso.updateCounter();

Event.domReady.add(function () {

		if (!pluso.notEmbeded) {
			pluso.init();

			pluso.addJS('+ping.php?t=show&u=' + encodeURIComponent(document.location.href) + "&ref=" + encodeURIComponent(document.referrer) + (pluso.screenWidth && pluso.screenHeight ? '&w=' + pluso.screenWidth + '&h='+ pluso.screenHeight : ''));
			new Image().src = "//counter.yadro.ru/hit;PLUSO?r" + escape(document.referrer) + ((typeof(screen)=="undefined")?"" : ";s"+screen.width+"*"+screen.height+"*" + (screen.colorDepth?screen.colorDepth:screen.pixelDepth)) + ";u"+escape(document.URL) + ";h"+escape(document.title.substring(0,80)) + ";1" + pluso.randomString(5);

		}


	
});





