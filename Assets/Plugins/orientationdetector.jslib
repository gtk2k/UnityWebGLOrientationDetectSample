var OrientationDetectorLib = {
    $JS_OrientationDetectorLib_Context: {},

    JS_OrientationDetectorLib_Init: function (eventHandler) {
        JS_OrientationDetectorLib_Context.eventHandler = eventHandler;
        JS_OrientationDetectorLib_Context.cnv = document.querySelector('canvas');
        if (window.screen && screen.orientation) {
            window.addEventListener('orientationchange', function () {
                window.onresize = function () {
                    window.onresize = null;
                    if (JS_OrientationDetectorLib_Context.eventHandler) {
                        Module.dynCall_vi(JS_OrientationDetectorLib_Context.eventHandler, window.screen.orientation.angle);
                    }
                };
            });
            return 0;
        } else {
            return -1;
        }
    },

    JS_OrientationDetectorLib_GetOrientation: function () {
        if (window.screen && screen.orientation) {
            return window.screen.angle;
        } else {
            return -1;
        }
    },

    JS_OrientationDetectorLib_FullScreen: function () {
        if (JS_OrientationDetectorLib_Context.cnv)
            JS_OrientationDetectorLib_Context.cnv.requestFullscreen();
    },

    JS_OrientationDetectorLib_ExitFullScreen: function () {
        if (JS_OrientationDetectorLib_Context.cnv)
            document.exitFullscreen();
    },

    JS_OrientationDetectorLib_Lock: function () {
        _JS_OrientationDetectorLib_FullScreen();
        setTimeout(function () {
            window.screen.orientation.lock('landscape-primary').then(function() {
                console.log('lock success');
                JS_OrientationDetectorLib_Context.isScreenLock = true;
            }).catch(function() {
                console.log('could not lock');
            });
        }, 0);
    },

    JS_OrientationDetectorLib_Unlock: function () {
        if (JS_OrientationDetectorLib_Context.isScreenLock) {
            screen.orientation.unlock();
            JS_OrientationDetectorLib_Context.isScreenLock = false;
        }
    }
};

autoAddDeps(OrientationDetectorLib, '$JS_OrientationDetectorLib_Context');
mergeInto(LibraryManager.library, OrientationDetectorLib);