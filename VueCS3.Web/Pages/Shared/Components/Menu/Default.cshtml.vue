<template>
  <li class="nav-item">
    <a class="nav-link text-dark" :class="isActive" :href="link">{{name}}</a>
  </li>
</template>

<script lang="ts">
  import { Component, Prop, Vue } from 'vue-property-decorator';

  @Component
  export default class MenuItem extends Vue {
    @Prop({ required: true, type: String })
    private link!: string;

    @Prop({ required: true, type: String })
    private name!: string;

    @Prop({ required: true, type: String })
    private slug!: string;

    get isActive() {
      return {
        active: this.slug === window.location.pathname,
      };
    }
  }
</script>

<style lang="scss" scoped>
  li a.active {
    color: darkcyan !important;
  }
</style>

