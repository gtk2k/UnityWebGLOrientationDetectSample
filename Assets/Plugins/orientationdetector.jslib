var OrientationDetectorLib = {
    $JS_OrientationDetectorLib_Context: {},

    JS_OrientationDetectorLib_Init: function (eventHandler) {
        JS_OrientationDetectorLib_Context.eventHandler = eventHandler;
        JS_OrientationDetectorLib_Context.cnv = document.querySelector('canvas');
        if(!('requestFullscreen' in document.documentElement)) {
            if (JS_OrientationDetectorLib_Context.eventHandler) {
                Module.dynCall_vi(JS_OrientationDetectorLib_Context.eventHandler, -999);
                Module.dynCall_vi(JS_OrientationDetectorLib_Context.eventHandler, window.orientation);
            }
        }
        window.onOrientationChange = function(val) {
            Module.dynCall_vi(JS_OrientationDetectorLib_Context.eventHandler, val);
        }
    },

    JS_OrientationDetectorLib_GetOrientation: function () {
        if (window.screen && screen.orientation) {
            return window.screen.angle;
        } else {
            return window.orientation;
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