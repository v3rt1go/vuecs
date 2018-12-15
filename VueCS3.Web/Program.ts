import Vue from 'vue';
import Layout from './Pages/Shared/_Layout.cshtml.vue';

Vue.config.productionTip = false;
Vue.config.ignoredElements = ['partial', 'environment', 'cache'];

// automagically register global components (pages)
// https://timleland.com/register-global-vue-components-using-webpack/
const requireComponent = require.context('./Pages', true, /[a-zA-Z]\w+\.cshtml.(vue|js)$/);

requireComponent.keys().forEach((fileName) => {
  // Get component config
  const componentConfig = requireComponent(fileName);
  const componentName = 'page-' + fileName.toLowerCase()
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
  render: (h) => h(Layout),
}).$mount('#app');
