define(function(require) {
    'use strict';

    var jQuery = require('jQuery');

    var PREVIOUS_SNAP_SELECTOR = '.js-snapScroll-previous';
    var NEXT_SNAP_SELECTOR = '.js-snapScroll-next';

    var SnapScroll = function(groupSelector) {
        this._groupSelector = groupSelector;

        jQuery(window).on('scroll', this._onWindowScroll.bind(this));

        jQuery(PREVIOUS_SNAP_SELECTOR).on('click', this._onPreviousSnapClick.bind(this));
        jQuery(NEXT_SNAP_SELECTOR).on('click', this._onNextSnapClick.bind(this));

        this._loadElements();
    };

    SnapScroll.prototype = {

        _$scrollTargetElements: null,
        _currentlyVisibleTargetIndex: -1,

        constructor: SnapScroll,

        _loadElements: function() {
            this._$scrollTargetElements = jQuery(this._groupSelector);
            this._findCurrentlyVisibleTarget();
        },

        _onWindowScroll: function(e) {
            this._findCurrentlyVisibleTarget();
        },

        _findCurrentlyVisibleTarget: function() {
            var $scrollTargetElements = this._$scrollTargetElements;

            var $window = jQuery(window);
            var windowScrollTop = $window.scrollTop();
            var windowScrollBottom = windowScrollTop + $window.height();

            var currentlyVisibleTargetIndex = -1;

            for (var i = 0; i < $scrollTargetElements.length; i++) {
                var currentTargetTop = $scrollTargetElements.eq(i).offset().top;

                if (currentTargetTop <= windowScrollTop) {
                    currentlyVisibleTargetIndex++;
                }

                if (i === $scrollTargetElements.length - 1 && currentTargetTop < windowScrollTop) {
                    currentlyVisibleTargetIndex++;
                }
            }

            this._currentlyVisibleTargetIndex = currentlyVisibleTargetIndex;
        },

        _onPreviousSnapClick: function(e) {
            e.preventDefault();

            this._scrollToTarget(this._currentlyVisibleTargetIndex - 1);
        },

        _onNextSnapClick: function(e) {
            e.preventDefault();

            this._scrollToTarget(this._currentlyVisibleTargetIndex + 1);
        },

        _scrollToTarget: function(targetIndex) {
            var $scrollTargetElements = this._$scrollTargetElements;

            var newScrollTop;

            if (targetIndex < 0) {
                newScrollTop = 0;
            } else if (targetIndex > $scrollTargetElements.length - 1) {
                newScrollTop = jQuery(document).height() - jQuery(window).height()
            } else {
                newScrollTop = $scrollTargetElements.eq(targetIndex).offset().top;
                // this._currentlyVisibleTargetIndex = targetIndex;
            }

            jQuery('body').stop().animate({
                scrollTop: newScrollTop
            }, 1000);
        }
    };

    return SnapScroll;
});