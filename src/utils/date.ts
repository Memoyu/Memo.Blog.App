import dayjs from "dayjs";

// 时间差计算
export function dateDiff(date?: Date) {
  if (!date) return "";
  if (typeof date === "string") {
    date = new Date(date);
  }
  // console.log(date);
  let dateTimeStamp = date.getTime();
  let minute = 1000 * 60;
  let hour = minute * 60;
  let day = hour * 24;
  let month = day * 30;
  let year = day * 365;
  let now = new Date().getTime();
  let diffValue = now - dateTimeStamp;

  let yearC = diffValue / year;
  let monthC = diffValue / month;
  let weekC = diffValue / (7 * day);
  let dayC = diffValue / day;
  let hourC = diffValue / hour;
  let minC = diffValue / minute;

  let result;
  if (yearC >= 1) {
    result = parseInt(yearC.toString()) + "年前";
  } else if (monthC >= 1) {
    result = parseInt(monthC.toString()) + "月前";
  } else if (weekC >= 1) {
    result = parseInt(weekC.toString()) + "周前";
  } else if (dayC >= 1) {
    result = parseInt(dayC.toString()) + "天前";
  } else if (hourC >= 1) {
    result = parseInt(hourC.toString()) + "小时前";
  } else if (minC >= 1) {
    result = parseInt(minC.toString()) + "分钟前";
  } else {
    result = "刚刚";
  }
  return result;
}

export function dateFormat(date?: Date) {
  if (!date) return "";
  const time = dayjs(date).format("YYYYMDD");
  const nowDate = dayjs().format("YYYYMDD"); // 今天
  const yesterday = dayjs().subtract(1, "day").format("YYYYMDD"); // 前一天
  const mowYear = dayjs().format("YYYY"); // 今年
  const timeYear = dayjs(date).format("YYYY");

  // console.log(time, yesterday);
  if (time === nowDate) {
    // 如果是今天的 则展示 09:37
    return dayjs(date).format("HH:mm");
  } else if (time === yesterday) {
    // 如果是昨天的 则展示 昨天 09:37
    return "昨天 " + dayjs(date).format("HH:mm");
  } else if (mowYear === timeYear) {
    // 如果是今年的  则展示 6-21 09:37
    return dayjs(date).format("M-D HH:mm");
  } else {
    // 不是今年的则展示为 2022-10-4 09:37
    return dayjs(date).format("YYYY-MM-D  HH:mm");
  }
}
