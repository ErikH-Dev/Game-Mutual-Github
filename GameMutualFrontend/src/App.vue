<template>
  <div class="app-container">
    <NavigationSideBar :isSidebarOpen="isSidebarOpen" @toggle="toggleSidebar" />
    <div class="content" :style="{ marginLeft: isSidebarOpen ? '200px' : '0px' }">
      <router-view />
    </div>
  </div>
</template>

<script>
import NavigationSideBar from './components/NavigationSideBar.vue';

export default {
  components: {
    NavigationSideBar
  },
  data() {
    return {
      isSidebarOpen: false
    };
  },
  methods: {
    toggleSidebar() {
      this.isSidebarOpen = !this.isSidebarOpen;
    }
  }
};
</script>

<style scoped>
.app-container {
  display: flex;
}

.content {
  flex-grow: 1;
  transition: margin-left 0.25s;
}
</style>