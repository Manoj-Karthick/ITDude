<script setup>
import NavItem from "../components/NavItem.vue";
</script>

<template>
  <div class="grid grid-cols-12 bg-gray-100 p-2 h-lvh">
    <div class="col-span-2 pr-2">
      <NavItem></NavItem>
    </div>
    <div
      class="col-span-10 border-slate-200 border w-full rounded-lg p-4 bg-white"
    >
      <RouterView></RouterView>
    </div>
  </div>
</template>

<style></style>
