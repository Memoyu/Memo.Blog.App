// 时间差计算
export function dateDiff(date: Date) {
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
