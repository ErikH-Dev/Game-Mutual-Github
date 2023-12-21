<template>
  <div class="app-container">
    <CompareGamesContainer @selected-users-changed="handleSelectedUsersChanged" :isSidebarOpen="isSidebarOpen" @search-games="handleSearchGames" />
    <GamesContainer ref="gamescontainer" :isSidebarOpen="isSidebarOpen" :searchQuery="searchQuery" :pageNumber="pageNumber" :selectedUsers="selectedUsers" @selected-users-changed="handleSelectedUsersChanged" />
  </div>
</template>

<script>
import CompareGamesContainer from '../components/CompareGamesContainer.vue';
import GamesContainer from '../components/GameContainer.vue';

export default {
  data() {
    return {
      selectedUsers: [],
      searchQuery: '',
      pageNumber: 1,
    };
  },
  components: {
    CompareGamesContainer,
    GamesContainer,
  },
  methods: {
    handleSelectedUsersChanged(selectedUsers) {
      this.selectedUsers = selectedUsers;
      this.pageNumber = 1;
      this.handleSearchGames();
    },
    handleSearchGames(searchQuery, pageNumber) {
      this.searchQuery = searchQuery;
      this.pageNumber = pageNumber;
      this.$refs.gamescontainer.getGames(this.selectedUsers, searchQuery, this.pageNumber);
    },
  },
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

.compare-games {
  flex: 1;
  overflow: hidden;
}

.games-container {
  flex: 1;
  overflow: hidden;
}

@import url('https://fonts.googleapis.com/css2?family=Kanit:wght@300&display=swap');
</style>