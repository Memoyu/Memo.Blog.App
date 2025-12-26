<script setup lang="ts">
const notifies = [
  {
    messageId: "9598401806204933",
    isRead: true,
    messageType: 1,
    content:
      '{"visitorNickname":"剧中人","visitorAvatar":"http://bh-lay.com","title":"个人博客站点，启动！","belongId":"8715972916150277","commentType":0,"content":"2024 年还愿意玩个人博客的小伙伴，很少见了，希望我们都能坚持玩下去。"}',
    createTime: "2024-10-11T13:39:50.543",
  },
  {
    messageId: "9198506151378949",
    isRead: true,
    messageType: 1,
    content:
      '{"visitorNickname":"memoyu","visitorAvatar":"https://q1.qlogo.cn/g?b=qq&nk=754433528&s=100","title":"动态","belongId":"0","commentType":1,"content":"是该好好调理一下了！"}',
    createTime: "2024-08-01T22:41:07.086",
  },
  {
    messageId: "11117008926146565",
    isRead: true,
    messageType: 2,
    content:
      '{"visitorNickname":"memoyu","visitorAvatar":"https://q1.qlogo.cn/g?b=qq&nk=754433528&s=100","title":"动态","belongId":"10890512601251845","likeType":1}',
    createTime: "2025-07-06T18:21:36.255",
  },
  {
    messageId: "10646667238440965",
    isRead: true,
    messageType: 2,
    content:
      '{"visitorNickname":"未知","visitorAvatar":"","title":"动态","belongId":"10059558799212549","likeType":1}',
    createTime: "2025-04-14T16:47:31.656",
  },
];
</script>
<template>
  <van-list sticky>
    <van-cell v-for="item in notifies" :key="item.messageId">
      <div class="notify">
        {{ item.content }}
      </div>
    </van-cell>
  </van-list>
</template>

<route lang="json5">
{
  name: "Comment",
  meta: {
    title: "评论&赞",
  },
}
</route>
