<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import '@assets/css/site.css';
import '@assets/js/site.js';

@Component({
  template: '#app',
})
export default class Layout extends Vue {
  public test: string = 'Vue is working';
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
