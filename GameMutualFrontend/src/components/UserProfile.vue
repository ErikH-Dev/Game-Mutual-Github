<template>
    <div v-if="user" class="profile-container">
        <img :src="user.picture" alt="Profile Picture">
        <h1>{{ user.name }}</h1>
        <button @click="ShowGames">Show Games</button>
    </div>
    <GameContainer />
</template>
  
<script>
import { computed } from 'vue';
import { useStore } from 'vuex';
import GameContainer from '../components/GameContainer.vue';

export default {
    name: 'UserProfile',
    setup() {
        const store = useStore();
        const user = computed(() => store.state.user);
        const readStateData = () => {
            console.log(store.state.user);
        }
        return { user, readStateData };
    },
    components: {
        GameContainer
    },
    methods: {
        ShowGames() {
            this.$refs.gamescontainer.getGames(this.selectedUsers, null, 1);
        }
    }
};
</script>
  
<style>
.profile-container {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    width: 100%;
    background-color: var(--secondary-accent);
    color: #fff;
    min-width: 800px;
}

.profile-container img {
    margin: 20px;
    width: 200px;
    height: 200px;
    border-radius: 20%;
}
</style>