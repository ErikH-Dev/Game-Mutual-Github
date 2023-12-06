<template>
  <div id="main-content" :style="mainContentStyles" ref="compareGamesContainer">
    <div class="compare-container">
      <div class="compare-container-content">
        <div class="content-container">
          <SearchUserComponent ref="searchUserComponent" @selected-users-changed="handleSelectedUsersChanged"></SearchUserComponent>
        </div>
        <div class="content-container">
          <SearchGamesComponent @search-games="handleSearchGames" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import SearchUserComponent from './SearchUserComponent.vue';
import SearchGamesComponent from './SearchGamesComponent.vue';

export default {
  name: 'CompareGames',
  data() {
    return {
      searchQuery: '',
    };
  },
  methods: {
    handleSearchGames(searchQuery) {
      this.searchQuery = searchQuery;
      this.$emit('search-games', searchQuery);
    },
    handleSelectedUsersChanged(selectedUsers) {
    this.selectedUsers = selectedUsers;
    this.$emit("selected-users-changed", this.selectedUsers);
  },
  },
  props: ['isSidebarOpen'],
  computed: {
    mainContentStyles() {
      return {
        marginLeft: this.isSidebarOpen ? '240px' : '60px',
        transition: 'margin-left 0.25s ease-in-out',
      };
    },
  },
  components: { SearchUserComponent, SearchGamesComponent },
};
</script>

<style>
.compare-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 100%;
  background-color: var(--secondary-accent);
  color: #fff;
  min-width: 800px;
}
.compare-container-content {
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  width: 100%;
}

.content-container {
  background-color: var(--primary-accent);
  border-radius: 50px;
  margin: 10px;
  width: 100%;
}

input {
  border: 2px transparent var(--primary-accent);
  border-radius: 15px;
  padding: 1rem;
  margin: 10px;
  font-size: 16px;
  text-align: center;
}

input:focus,
input:hover {
  border: 2px solid var(--primary-accent);
  transition: ease-in-out 100ms;
  box-shadow: none;
}

.fetch-button {
  font-size: 16px;
  border: none;
  background-color: var(--tartiary-accent);
  border-radius: 20px;
  padding: 1rem 2rem 1rem 2rem;
}

.fetch-button:hover {
  background-color: #fff;
  border: 2px solid var(--tartiary-accent);
  transition: 150ms;
}
</style>