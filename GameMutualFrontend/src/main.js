import { createApp } from 'vue';
import App from './App.vue';
// Router
import router from './router.js';

// CSS
import './assets/css/main.css';

// Auth0
import { createAuth0 } from '@auth0/auth0-vue';

// Vuex
import { createStore } from 'vuex';
const store = createStore({
  state() {
    return {
      user: null,
    }
  },
  mutations: {
    setUser(state, user) {
      let auth0User = {
        Subject: user.sub,
        Name: user.name,
        Email: user.email,
        Picture: user.picture,
      };

      fetch('https://localhost:7257/api/User/Create', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(auth0User),
      })
        .then(response => response.json())
        .then(data => {
          console.log(data);
          state.user = data;
        })
        .catch((error) => console.error('Error:', error));
    },
  },
});

// Icons
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faHouse, faUser, faGamepad, faCog, faCancel, faSignIn, faSignOut } from '@fortawesome/free-solid-svg-icons';
library.add(faHouse, faGamepad, faUser, faCog, faCancel, faSignIn, faSignOut)

// CreateApp
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
app.use(store);
app.mount('#app');