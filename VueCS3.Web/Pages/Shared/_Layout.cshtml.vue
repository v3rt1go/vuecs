<script lang="ts">
  import { Component, Vue } from 'vue-property-decorator';
  import 'bootstrap/dist/css/bootstrap.css';
  import 'bootstrap-vue/dist/bootstrap-vue.css';
  import '@assets/js/site.js';
  import '@assets/css/site.css';


  @Component({
    template: '#app',
  })
  export default class Layout extends Vue {
    public appTitle: string = 'VueCS - Vue.js powered Razor Pages';
  }
</script>

<style lang="scss">
  #app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }
</style>
