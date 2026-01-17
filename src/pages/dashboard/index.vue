<script setup lang="ts">
defineOptions({
  name: "Dashboard",
});
</script>

<template>
  <statistics />
  <ranking />
  <visitor-map />
</template>

<route lang="json5">
{
  name: "Dashboard",
  path: "/",
  meta: {
    title: "概览",
    keepAlive: true,
  },
}
</route>
