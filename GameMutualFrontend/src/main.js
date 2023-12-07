import { createApp } from 'vue';
import App from './App.vue';
import './assets/css/main.css';
import router from './router.js';
import { createAuth0 } from '@auth0/auth0-vue';

import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faHouse, faUser, faGamepad, faCog, faCancel } from '@fortawesome/free-solid-svg-icons';

library.add(faHouse, faGamepad, faUser, faCog, faCancel)

const app = createApp(App);
app.use(
    createAuth0({
      domain: "dev-kmqdknosvd5rflkf.us.auth0.com",
      clientId: "P7sEQTaTEGzkgneUwZNQWXtaCuNSQwrG",
      authorizationParams: {
        redirect_uri: window.location.origin,
        audience: "GameMutualAPI",
      }
    })
  );
  
app.component('font-awesome-icon', FontAwesomeIcon);
app.use(router);
app.mount('#app');