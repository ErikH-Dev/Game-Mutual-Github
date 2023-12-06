<template>
  <div class="search-user-container">
    <h1>Search user</h1>
    <p>Enter a Steam user ID to compare with.</p>
    <div id="search-result" v-if="userFound">
      <button class="read-user" @click="addUser">
        <img class="avatar" :src="user.avatarfull" alt="Steam User Icon" />
        <span>{{ user.personaname }}</span>
      </button>
    </div>
    <div v-if="error">
      <p>{{ error }}</p>
    </div>
    <input id="search-bar" v-model="steamUserId" @input="fetchUser" @keyup.enter="addUserOnEnter"
      placeholder="Enter Steam User ID" />
    <div class="selected-users-container" v-if="searchedUsers.length > 0">
      <p>Selected Users</p>
      <div v-for="(userData, index) in searchedUsers" :key="index" class="selected-user">
        <div class="user-info">
          <img class="avatar" :src="userData.avatarfull" alt="Steam User Icon" />
          <span>{{ userData.personaname }}</span>
        </div>
        <button class="remove-button" @click="removeUser(index)">
          <font-awesome-icon icon="fa-solid fa-cancel" />
        </button>
      </div>
      <button class="remove-all-button" @click="removeAllUsers">Remove All</button>
    </div>
    <span v-if="isLoading" class="loader"></span>
  </div>
</template>
  
<script>
export default {
  data() {
    return {
      steamUserId: "",
      user: null,
      userFound: false,
      error: null,
      searchedUsers: [],
      isLoading: false,
    };
  },
  methods: {
    async fetchUser() {
      this.error = null;
      this.userFound = false;
      this.isLoading = true;

      clearTimeout(this.timer);
      this.timer = setTimeout(async () => {
        let apiUrl;
        if (/^\d{17}$/.test(this.steamUserId)) {
          apiUrl = `https://localhost:7257/api/SteamUser/GetByID/${this.steamUserId}`;
        } else if (/^[\w\d_]{3,32}$/.test(this.steamUserId)) {
          apiUrl = `https://localhost:7257/api/SteamUser/GetByCustomID/${this.steamUserId}`;
        } else {
          this.error = "Invalid user ID";
          this.isLoading = false;
          return;
        }

        try {
          const response = await fetch(apiUrl);
          const users = await response.json();

          if (users.length > 0) {
            this.user = users[0];
            this.userFound = true;
            // Emit the Steam64Id instead of the vanity URL
            this.$emit("steam-user-id-fetched", this.user.steamid);
          } else {
            this.user = null;
            this.userFound = false;
            this.error = "User not found";
          }
        } catch (error) {
          console.error("Error fetching user:", error);
          this.user = null;
          this.userFound = false;
          this.error = "Error while getting user data. Please try again.";
        } finally {
          this.isLoading = false;
        }
      }, 1000);
    },
    addUser() {
      if (!this.searchedUsers.some(user => user.steamUserId === this.steamUserId)) {
        this.searchedUsers.push({
          steamUserId: this.user ? this.user.steamid : this.steamUserId,
          avatarfull: this.user ? this.user.avatarfull : "",
          personaname: this.user ? this.user.personaname : "",
        });
        this.$emit("selected-users-changed", this.searchedUsers.map((user) => user.steamUserId));
        this.steamUserId = "";
        this.userFound = false;
      }
    },
    addUserOnEnter() {
      if (this.userFound) {
        this.addUser();
      }
    },
    removeUser(index) {
      this.searchedUsers.splice(index, 1);
      this.$emit("selected-users-changed", this.searchedUsers.map((user) => user.steamUserId));
    },
    removeAllUsers() {
      this.searchedUsers = [];
      this.$emit("selected-users-changed", []);
    },
  },
};
</script>
  
<style>
.search-user-container {
  text-align: center;
  display: flex;
  flex-direction: column;
  align-items: center;
}

#search-bar {
  width: 40%;
}

#search-result {
  display: flex;
  flex-direction: row;
  justify-content: center;
}

.read-user {
  display: flex;
  align-items: center;

  border: none;
  border-radius: 15px;
  padding: 1rem;
  margin: 10px;
  font-size: 21px;
  text-align: center;
  background-color: var(--secondary-accent);
  transition: 150ms;
}

.read-user:hover {
  background-color: #71c777;
  cursor: pointer;
}

.avatar {
  width: 55px;
  height: 55px;
  margin-right: 8px;
  border-radius: 5px;
}

.selected-users-container {
  position: fixed;
  bottom: 10px;
  right: 10px;
  background-color: var(--tartiary-accent);
  border-radius: 15px;
  padding: 10px;
  z-index: 2;
}

.selected-user {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background-color: var(--secondary-accent);
  margin: 5px;
  padding: 5px;
  border-radius: 5px;
  transition: 0.3s ease-in-out;
  font-size: 16px;
}

.selected-user:hover {
  background-color: rgba(var(--remove), 0.5);
}

.user-info {
  display: flex;
  align-items: center;
}

.remove-button {
  background-color: var(--remove);
  color: #fff;
  border: none;
  border-radius: 15px;
  padding: 5px 10px;
  cursor: pointer;
  opacity: 0;
  transition: opacity 0.3s ease-in-out;
}

.selected-user:hover .remove-button {
  opacity: 1;
}

.remove-all-button {
  background-color: var(--remove);
  color: #fff;
  border: none;
  border-radius: 5px;
  padding: 5px 10px;
  cursor: pointer;
}

.loader {
  width: 48px;
  height: 48px;
  border: 5px solid #FFF;
  border-bottom-color: transparent;
  border-radius: 50%;
  display: inline-block;
  box-sizing: border-box;
  animation: rotation 1s linear infinite;
}

@keyframes rotation {
  0% {
    transform: rotate(0deg);
  }

  100% {
    transform: rotate(360deg);
  }
}
</style>
  