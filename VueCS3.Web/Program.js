import Vue from 'vue';
import Layout from './Pages/Shared/_Layout.cshtml.vue';
Vue.config.productionTip = false;
Vue.config.ignoredElements = ['partial', 'environment', 'cache'];
// automagically register global components (pages)
// https://timleland.com/register-global-vue-components-using-webpack/
var requireComponent = require.context('./Pages', true, /[a-zA-Z]\w+\.cshtml.(vue|js)$/);
requireComponent.keys().forEach(function (fileName) {
    // Get component config
    var componentConfig = requireComponent(fileName);
    var componentName = 'page-' + fileName.toLowerCase()
        // Remove the "./" from the beginning
        .replace(/^\.\//, '')
        // Remove any occuraces of _ in the filenam
        .replace(/\_/g, '')
        // Remove the file extensions from the end
        .replace(/\.\w+/g, '')
        // Replace all / with -
        .replace(/\//g, '-');
    // Globally register the component
    Vue.component(componentName, componentConfig.default || componentConfig);
});
new Vue({
    render: function (h) { return h(Layout); },
}).$mount('#app');
//# sourceMappingURL=Program.js.map