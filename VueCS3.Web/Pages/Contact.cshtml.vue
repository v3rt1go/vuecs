<script lang="ts">
  import { Component, Vue } from 'vue-property-decorator';

  @Component
  export default class Contact extends Vue {
    public contactTest: string = 'Vue din contact data';
    public msg: string = 'When using inline templates it\'s harder to call them as children';
  }
</script>
