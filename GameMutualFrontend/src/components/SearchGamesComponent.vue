<template>
  <div class="search-games-container">
    <h1>Search Games</h1>
    <input v-model="searchQuery" type="text" placeholder="Search by game name" @input="handleInput" />
  </div>
</template>

<script>
export default {
  name: 'SearchGamesComponent',
  data() {
    return {
      searchQuery: '',
      pageNumber: 1,
    };
  },
  methods: {
    handleInput() {
      clearTimeout(this.timer);
      this.timer = setTimeout(() => {
        this.$emit('search-games', this.searchQuery, this.pageNumber);
      }, 500);
    },
  },
};
</script>
<style>
.search-games-container {
    text-align: center;
    display: flex;
    flex-direction: column;
    align-items: center;
}
h1 {
  margin: 0px;
}
</style>
