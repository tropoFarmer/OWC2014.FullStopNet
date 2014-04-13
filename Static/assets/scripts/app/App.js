define(function(require) {
    'use strict';

    var jQuery = require('jQuery');

    var ResponsiveTriggers = require('app/lib/ResponsiveTriggers');
    var SnapScroll = require('app/lib/SnapScroll');

    // singletons with no interface
    require('app/lib/ActiveToggler');

    var App = function() {
        console.log('App initialized.');

        var responsiveTriggers = new ResponsiveTriggers([
            {
                id: 'small',
                maxWidth: 320
            },
            {
                id: 'medium',
                maxWidth: 640
            },
            {
                id: 'desktop',
                maxWidth: Infinity
            }
        ]);


        var homePageSnapScroll = new SnapScroll('.contentSection');

    };

    return App;
});