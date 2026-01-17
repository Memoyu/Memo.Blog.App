<template>
  <div class="list-card-box"><slot></slot></div>
</template>

<style lang="less" scoped>
.list-card-box {
  position: relative;
  padding: 10px var(--van-padding-md);
  // background: var(--van-background-2);

  &::after {
    position: absolute;
    box-sizing: border-box;
    content: " ";
    pointer-events: none;
    right: var(--van-padding-md);
    bottom: 0;
    left: var(--van-padding-md);
    border-bottom: 1px solid var(--van-border-color);
  }
}
</style>
