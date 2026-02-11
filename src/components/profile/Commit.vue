<script setup lang="ts">
const showTip = ref(false);
const tipRef = ref();
const tipContent = ref("");

function onBlockClick(event: MouseEvent) {
  var target = event?.target as HTMLElement;
  // console.log(target);
  if (!target) return;
  var rect = target.getBoundingClientRect();
  // console.log(rect);
  tipContent.value = `这是${rect.width}x${rect.height}的块`;
  nextTick(() => {
    const w = tipRef.value.offsetWidth;
    console.log(tipRef.value.offsetWidth);
    tipRef.value.style.left = rect.left - w / 2 + "px";
    tipRef.value.style.top = rect.top - rect.height - 18 + "px";
    showTip.value = true;
  });
}
</script>

<template>
  <div class="commit-box space-x-5">
    <div v-for="m in 12" :key="m" style="min-width: 110px">
      <div class="flex flex-wrap content-center">
        <div
          v-for="value in 35"
          :key="value"
          style="width: 18px; height: 18px; background-color: gray; margin: 2px"
          @click="onBlockClick"
        />
      </div>
      <div class="font-bold text-center">{{ m }}月</div>
    </div>
    <div ref="tipRef" v-show="showTip" class="commit-tip">{{ tipContent }}</div>
  </div>
</template>

<style lang="less" scoped>
.commit-box {
  display: flex;
  overflow: auto;
  background: var(--van-background-2);
  --at-apply: p-10 mt-20 my-9 rounded-2xl h-200;
}

.commit-tip {
  position: absolute;
  padding: 4px 8px;
  border-radius: 12px;
  background: var(--van-background-2);
}
</style>
