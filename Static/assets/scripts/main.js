/* ---------------------------------------------------------------------
Global JavaScript

Target Browsers: All
Authors: Fullstop Net
------------------------------------------------------------------------ */

// Namespace Object
var APP = APP || {};

// Pass reference to jQuery and Namespace
(function($, APP) {

    // DOM Ready Function
    $(function() {
        APP.HasJS.init();
        APP.ExternalLinks.init();
        APP.AutoReplace.init();
    });

/* ---------------------------------------------------------------------
HasJS
Author: Boilerplate

Replaces "no-js" class with "js" on the html element if JavaScript
is present. This allows you to style both the JavaScript enhanced
and non JavaScript experiences.
------------------------------------------------------------------------ */
APP.HasJS = {
    init: function() {
        $('html').removeClass('no-js').addClass('js');
    }
};

/* ---------------------------------------------------------------------
ExternalLinks
Author: Boilerplate

Launches links with a rel="external" in a new window
------------------------------------------------------------------------ */
APP.ExternalLinks = {
    init: function() {
        $(document).on('click', 'a[rel=external]', function(e) {
            window.open($(this).attr('href'));
            e.preventDefault();
        });
    }
};

/* ---------------------------------------------------------------------
AutoReplace
Author: Boilerplate

Mimics HTML5 placeholder behavior in browsers that do not support it.

Additionally, adds and removes 'placeholder-text' class, used as a styling
hook for when placeholder text is visible or not visible

Additionally, sets the field value to the empty string upon form submission
if the current value is the default text
------------------------------------------------------------------------ */
APP.AutoReplace = {
    $fields: undefined,

    init: function() {
        // Only run the script if 'placeholder' is not natively supported
        if ('placeholder' in document.createElement('input')) {
            return;
        }

        this.$fields = $('[placeholder]');
        this.bind();
    },

    bind: function() {
        this.$fields.each(
            function() {
                var $this = $(this);
                var defaultText = $this.attr('placeholder');

                if ($this.val() === '' || $this.val() === defaultText) {
                    $this.addClass('placeholder-text').val(defaultText);
                }

                $this.off('.autoreplace');

                $this.on(
                    'focus.autoreplace',
                    function() {
                        if ($this.val() === defaultText) {
                            $this.val('').removeClass('placeholder-text');
                        }
                    }
                );

                $this.on(
                    'blur.autoreplace',
                    function() {
                        if ($this.val() === '' || $this.val() === defaultText) {
                            $this.val(defaultText).addClass('placeholder-text');
                        }
                    }
                );

                $this.parents('form').off('submit.autoreplace').on(
                    'submit.autoreplace',
                    function() {
                        if ($this.val() == defaultText) {
                            $this.val('');
                        }
                    }
                );
            }
        );
    }
};

}(jQuery, APP));