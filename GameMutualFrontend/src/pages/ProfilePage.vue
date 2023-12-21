<template>
    <div class="app-container">
        <UserProfile />
    </div>
</template>

<script>
import UserProfile from '../components/UserProfile.vue';

export default {
    components: {
        UserProfile,
    },
    methods: {
        toggleSidebar() {
            this.isSidebarOpen = !this.isSidebarOpen;
        },
    },
    props: {
      user: {
        type: Object,
        required: true
      }
    }
};
</script>
<style>
.app-container {
  display: flex;
  font-family: 'Kanit', sans-serif;
  width: 100%;
  transition: ease-in-out;
  flex-direction: column;
}

@import url('https://fonts.googleapis.com/css2?family=Kanit:wght@300&display=swap');
</style>