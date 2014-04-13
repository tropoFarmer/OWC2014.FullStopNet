define(function(require) {
    'use strict';

    var jQuery = require('jQuery');

    var TARGET_SELECTOR = '.js-toggleActive';
    var ACTIVE_CLASS = 'active';

    var ActiveToggler = {
        init: function() {
            jQuery(TARGET_SELECTOR).on('click', this._toggleActive.bind(this));
        },

        _toggleActive: function(e) {
            e.preventDefault();

            var $currentTarget = jQuery(e.currentTarget);
            if ($currentTarget.hasClass(ACTIVE_CLASS) === true) {
                $currentTarget.removeClass(ACTIVE_CLASS);
            } else {
                $currentTarget.addClass(ACTIVE_CLASS);
            }
        }
    };

    ActiveToggler.init();

});