define(function(require) {
    'use strict';

    var jQuery = require('jQuery');

    var TARGET_SELECTOR = '.js-toggleActive-target';
    var ACTIVATOR_SELECTOR = '.js-toggleActive-activator';
    var ACTIVE_CLASS = 'active';

    var ActiveToggler = {
        init: function() {
            jQuery(ACTIVATOR_SELECTOR).on('click', this._toggleActive.bind(this));
        },

        _toggleActive: function(e) {
            e.preventDefault();

            var $elementToToggle = jQuery(e.currentTarget).closest(TARGET_SELECTOR);
            if ($elementToToggle.hasClass(ACTIVE_CLASS) === true) {
                $elementToToggle.removeClass(ACTIVE_CLASS);
            } else {
                $elementToToggle.addClass(ACTIVE_CLASS);
            }
        }
    };

    ActiveToggler.init();

});