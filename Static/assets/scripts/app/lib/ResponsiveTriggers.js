define(function(require) {
    'use strict';

    var jQuery = require('jQuery');

    var ResponsiveTriggers = function(breakpoints) {

        this._breakpoints = breakpoints;
        this._onBreakpointChangeCallbacks = [];

        // ensure breakpoints contain required fields, sort, etc.
        this._validateBreakpoints();

        window.addEventListener('resize', this._onWindowResize.bind(this));

        this._checkBreakpoints();
    };

    ResponsiveTriggers.prototype = {
        _breakpoints: null,
        _onBreakpointChangeCallbacks: null,
        _currentBreakpointId: '',

        constructor: ResponsiveTriggers,

        _validateBreakpoints: function(breakpoints) {
            for (var i = 0; i < this._breakpoints.length; i++) {
                var breakpoint = this._breakpoints[i];

                if (breakpoint.id === undefined) {
                    throw new Error('Invalid breakpoint configuration; each breakpoint requires a "id" property');
                }

                if (breakpoint.maxWidth === undefined) {
                    throw new Error('Invalid breakpoint configuration; each breakpoint requires a "maxWidth" property');
                }
            }

            // ensure the breakpoints are sorted correctly
            this._breakpoints.sort(function(a, b) {
                return a.maxWidth > b.maxWidth;
            });
        },

        _onWindowResize: function(e) {
            this._checkBreakpoints();
        },

        _checkBreakpoints: function() {

            var currentWidth = jQuery(window).width();

            for (var i = 0; i < this._breakpoints.length; i++) {
                var breakpoint = this._breakpoints[i];
                if (currentWidth > breakpoint.maxWidth) {
                    continue;
                }

                // check for the breakpoint to actually be changing
                if (breakpoint.id === this._currentBreakpointId) {
                    return;
                }

                this._currentBreakpointId = breakpoint.id;

                // we've found the breakpoint we're within
                console.log('breakpoint change: ', breakpoint.id);

                for (var i = 0; i < this._onBreakpointChangeCallbacks.length; i++) {
                    this._onBreakpointChangeCallbacks[i](breakpoint);
                }

                return;
            }
        },

        onBreakpointChange: function(fn) {
            if (fn instanceof Function === false) {
                throw new Error('ResponsiveTriggers.onBreakpointChange(): invalid callback parameter provided; expecting function');
            }

            this._onBreakpointChangeCallbacks.push(fn);
        }
    }

    return ResponsiveTriggers;
});