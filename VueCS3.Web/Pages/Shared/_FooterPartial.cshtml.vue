<script lang="ts">
  import { Component, Prop, Vue } from 'vue-property-decorator';

  @Component
  export default class Footer extends Vue {
    public currentYear: number = (new Date()).getFullYear();

    @Prop() private test!: string;
  }
</script>

<style scoped lang="scss">
  .footer {
    position: absolute;
    bottom: 0;
    width: 100%;
    white-space: nowrap;
    /* Set the fixed height of the footer here */
    height: 60px;
    line-height: 60px; /* Vertically center the text there */
  }
</style>
