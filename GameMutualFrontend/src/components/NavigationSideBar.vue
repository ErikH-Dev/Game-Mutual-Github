<template>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <div id="hamburger-menu" class="sidebar">
        <a id="hamburger-icon" @click="toggleNav"><i class="fa fa-bars"></i></a>
        <hr>
        <div class="nav-container">
            <div class="nav-item">
                <a class="nav-item-icon" href="/"><font-awesome-icon icon="fa-solid fa-house" /></a>
                <span>Home</span>
            </div>
            <div class="nav-item">
                <a class="nav-item-icon" href="/"><font-awesome-icon icon="fa-solid fa-gamepad" /></a>
                <span>Mutual games</span>
            </div>
            <div class="nav-item">
                <a class="nav-item-icon" href="/"><font-awesome-icon icon="fa-solid fa-user" /></a>
                <span>My profile</span>
            </div>
        </div>
        <hr>
        <div class="favourites-list">
            <a class="favourite-item" href="/"><font-awesome-icon icon="fa-solid fa-user" /><span>Friend</span></a>
            <a class="favourite-item" href="/"><font-awesome-icon icon="fa-solid fa-user" /><span>Friend</span></a>
            <a class="favourite-item" href="/"><font-awesome-icon icon="fa-solid fa-user" /><span>Friend</span></a>
            <a class="favourite-item" href="/"><font-awesome-icon icon="fa-solid fa-user" /><span>Friend</span></a>
            <a class="favourite-item" href="/"><font-awesome-icon icon="fa-solid fa-user" /><span>Friend</span></a>
        </div>
        <div class="user-info">
            <UserInformation />
            <LogoutButton />
        </div>
    </div>
</template>

<script>
import LogoutButton from './LogoutButton.vue';
import UserInformation from './UserInformation.vue';

export default {
    props: ['isSidebarOpen'],
    components: {
        LogoutButton,
        UserInformation
    },
    methods: {
        toggleNav() {
            this.$emit('toggle');
            const sidebar = document.getElementById("hamburger-menu");
            const sidebarWidth = sidebar.style.width;
            const navItems = document.querySelectorAll(".nav-item span");
            const favouriteItems = document.querySelectorAll(".favourite-item span")

            if (sidebarWidth === "60px" || sidebarWidth === "") {
                sidebar.style.width = "240px";
                setTimeout(() => {
                    navItems.forEach(item => item.classList.remove("hidden-text"));
                    favouriteItems.forEach(item => item.classList.remove("hidden-text"));
                }, 250);
            } else {
                sidebar.style.width = "60px";
                navItems.forEach(item => item.classList.add("hidden-text"));
                favouriteItems.forEach(item => item.classList.add("hidden-text"));
            }
        }
    },
    computed: {
        sidebarStyles() {
            return {
                width: this.isSidebarOpen ? '240px' : '60px',
            };
        },
    },
};

</script>

<style>
.sidebar {
    display: flex;
    flex-direction: column;
    color: #fff;
    height: 100%;
    width: 300px;
    position: fixed;
    z-index: 1;
    top: 0;
    left: 0;
    background-color: var(--tartiary-accent);
    overflow-x: hidden;
    transition: 0.25s;
    padding-left: 10px;
    padding-right: 10px;
}

.sidebar hr {
    width: 100%;
    color: var(--secondary-accent);
}

.hidden-text {
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
    color: #fff;
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
}</style>