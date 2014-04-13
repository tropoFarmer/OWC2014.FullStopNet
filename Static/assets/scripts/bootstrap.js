requirejs.config({
    paths: {
        domReady: 'vendor/requirejs/domReady',
        text: 'vendor/requirejs/text',
        jQuery: 'vendor/jquery.min'
    },

    shim: {
        jQuery: {
            exports: 'jQuery'
        }
    }
});

require(['domReady', 'app/App'], function(domReady, App) {
    domReady(function() {
        new App();
    });
});