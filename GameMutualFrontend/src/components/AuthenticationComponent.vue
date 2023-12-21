<template>
    <div class="user-info" v-if="user">
        <img :src="user.picture" alt="Profile">
        <p>{{ user.name }}</p>
    </div>
    <button v-if="!isAuthenticated" @click="login" class="authentication-button">
        <span><font-awesome-icon class="nav-item-icon" icon="fa-solid fa-sign-in" />Log in</span>
    </button>
    <button v-if="isAuthenticated" @click="logout" class="authentication-button">
        <font-awesome-icon class="nav-item-icon" icon="fa-solid fa-sign-out" />
    </button>
    <button v-if="isAuthenticated" @click="readStateData" class="authentication-button">
        <font-awesome-icon class="nav-item-icon" icon="fa-solid fa-cog" />
    </button>
</template>
<script>
import { useAuth0 } from '@auth0/auth0-vue';
import { useStore } from 'vuex';

export default {
    name: 'AuthenticationComponent',
    setup() {
        const { loginWithRedirect, logout, user, isAuthenticated } = useAuth0();
        const store = useStore();

        const login = async () => {
            loginWithRedirect();
            readStateData();
        };

        const logoutUser = () => {
            logout({ returnTo: window.location.origin });
            store.commit('setUser', null);
        };
        const readStateData = () => {
            store.commit('setUser', user.value);
            console.log(store.state.user);
        };
        return {
            user,
            isAuthenticated,
            login,
            readStateData,
            logout: logoutUser,
        };
    },
};
</script>
<style scoped>
.user-info {
    width: 100%;
    display: flex;
    flex-direction: row;
    align-items: center;
}

.user-info img {
    width: 60px;
    height: 60px;
    border-radius: 50%;
    margin-right: 10px;
}
.authentication-button {
    display: flex;
    align-items: center;
    width: 100%;
    padding-bottom: 5px;
    background-color: transparent;
    border: none;
    color: #fff;
    font-size: 16px;
    cursor: pointer;
}
.nav-item-icon {
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 10px;
    width: 30px;
    height: 30px;
    background-color: var(--secondary-accent);
    border-radius: 15px;
    color: white;
    text-decoration: none;
}
</style>