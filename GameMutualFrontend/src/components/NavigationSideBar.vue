<template>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <div class="sidebar" :style="{ width: isSidebarOpen ? '240px' : '60px' }">
        <a id="hamburger-icon" @click="toggleNav"><i class="fa fa-bars"></i></a>
        <hr>
        <div class="nav-container" :class="{ 'hide-text': !isSidebarOpen }">
            <router-link class="nav-item" to="/">
                <font-awesome-icon class="nav-item-icon" icon="fa-solid fa-house" />
                <span>Home</span>
            </router-link>
            <router-link class="nav-item" to="/">
                <font-awesome-icon class="nav-item-icon" icon="fa-solid fa-gamepad" />
                <span>Mutual games</span>
            </router-link>
            <router-link class="nav-item" to="/profile">
                <font-awesome-icon class="nav-item-icon" icon="fa-solid fa-user" />
                <span>My profile</span>
            </router-link>
            <router-link v-if="isAuthenticated" class="nav-item" to="/settings">
                <font-awesome-icon class="nav-item-icon" icon="fa-solid fa-cog" />
                <span>Settings</span>
            </router-link>
        </div>
        <hr>
        <div class="favourites-list" :class="{ 'hide-text': !isSidebarOpen }">
            <span class="favourite-item"><font-awesome-icon icon="fa-solid fa-user" />Friend</span>
        </div>
        <div class="user-info">
            <AuthenticationComponent/>
        </div>
    </div>
</template>

<script>
import { useAuth0 } from '@auth0/auth0-vue';
import { useStore } from 'vuex';

import AuthenticationComponent from './AuthenticationComponent.vue';

export default {
    props: ['isSidebarOpen'],
    components: {
        AuthenticationComponent,
    },
    setup() {
        const { loginWithRedirect, user, isAuthenticated } = useAuth0();
        const { logout } = useAuth0();
        const store = useStore();
        const login = async () => {
            await loginWithRedirect();
            store.commit('setUser', user.value);
        };
        return {
            logout: () => {
                logout({ logoutParams: { returnTo: window.location.origin } });
            },
            login,
            isAuthenticated,
        };
    },
    methods: {
        toggleNav() {
            this.$emit('toggle');
        },
    },
};
</script>

<style scoped>
.sidebar {
    display: flex;
    flex-direction: column;
    color: #fff;
    height: 100%;
    width: 240px;
    position: fixed;
    z-index: 1;
    top: 0;
    left: 0;
    background-color: var(--tertiary-accent);
    overflow-x: hidden;
    transition: 0.25s;
    padding-left: 10px;
    padding-right: 10px;
}

.sidebar hr {
    width: 100%;
    color: var(--secondary-accent);
}

.hide-text span {
    display: none;
}

#hamburger-icon {
    height: 40px;
    width: 40px;
    color: var(--primary-accent);
    padding: 0.5vw;
}

.nav-container {
    display: flex;
    flex-direction: column;
}

.nav-item {
    display: flex;
    align-items: center;
    width: 100%;
    padding-bottom: 5px;
}

.nav-item span {
    margin-left: 10px;
    color: var(--primary-text);
}

.nav-item-icon {
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 10px;
    width: 40px;
    height: 40px;
    background-color: var(--secondary-accent);
    border-radius: 15px;
    color: white;
    text-decoration: none;
}

.favourites-list {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.favourites-list .favourite-item {
    text-decoration: none;
    color: var(--primary-text);
    width: 90%;
    margin: 2px;
    padding: 10px;
    transition: 150ms;
    background-color: var(--secondary-accent);
    border-radius: 15px;
}

.user-info {
    margin-top: auto;
    display: flex;
    flex-direction: row;
}
</style>