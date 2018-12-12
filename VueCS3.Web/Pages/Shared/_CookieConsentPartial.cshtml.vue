<template>
  <b-alert dismissible fade variant="info" :show="showCookieAlert">
    <slot name="consentText">
      Use this space to summarize your privacy and cookie use policy. <a :href="privacyLink" target="_blank">Privacy</a>.
    </slot>
    <b-button slot="dismiss" size="sm" variant="success" @click="setAppCookie">Accept</b-button>
  </b-alert>
</template>

<script lang="ts">
  import { Component, Prop, Vue } from 'vue-property-decorator';
  import bAlert from 'bootstrap-vue/es/components/alert/alert';
  import bButton from 'bootstrap-vue/es/components/button/button';

  @Component({
    components: {
      'b-alert': bAlert,
      'b-button': bButton,
    },
  })
  export default class CookieConsent extends Vue {
    // data
    public showCookieAlert: boolean = true;

    // props
    @Prop() private privacyLink!: string;
    @Prop() private cookieString!: string;

    // methods
    public setAppCookie() {
      document.cookie = this.cookieString;
      this.showCookieAlert = false;
    }
  }
</script>
