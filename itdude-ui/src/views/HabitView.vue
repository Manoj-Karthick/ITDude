<script>
import axios from "axios";
export default {
  data() {
    return {
      habitNames: [],
    };
  },
  methods: {
    addHabit() {},
    getHabits() {},
  },
  async mounted() {
    let result = await axios.get("https://localhost:7231/api/Habit/GetAll");
    this.habitNames = result.data;
  },
};
</script>
<template>
  <div v-for="habitName in habitNames">
    {{ habitName.habitName }}
  </div>
  <input
    type="text"
    class="border p-2 rounded-lg border-gray-300 focus:border-gray-600"
    placeholder="New habit name"
  />
  <br />
  <button
    class="mt-3 px-3 py-2 text-white bg-blue-600 rounded-lg hover:bg-blue-700"
    @click="addHabit"
  >
    Add habit
  </button>
</template>
