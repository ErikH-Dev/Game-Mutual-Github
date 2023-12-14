<template>
    <div>
        <button @click="login">Log in</button>
        <pre class="user-information" v-if="isAuthenticated">
        <img :src="user.picture" alt="Profile">
          <p>{{ user }}</p>
        </pre>
    </div>
</template>
<script>
import { useAuth0 } from '@auth0/auth0-vue';

export default {
    setup() {
        const { loginWithRedirect, user, isAuthenticated } = useAuth0();
        // const { getAccessTokenSilently } = useAuth0();
        return {
            login: () => {
                loginWithRedirect();
            },
            // doSomethingWithToken: async () => {
            //     const token = await getAccessTokenSilently();
            //     const response = await fetch()
            // },
            user,
            isAuthenticated
        };
    }
};
</script>
<style>
.user-information {
    display: flex;
    flex-direction: row;
    align-items: center;
}
.user-information img {
    width: 80px;
    height: 80px;
    border-radius: 50%;
    margin-right: 10px;}
</style>