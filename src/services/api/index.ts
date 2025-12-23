import user from "./user";
import dashboard from "./dashboard";
import article from "./article";
import moment from "./moment";
import friend from "./friend";
import openSource from "./open-source";
import logging from "./logging";

export default {
  ...user,
  ...dashboard,
  ...article,
  ...moment,
  ...friend,
  ...openSource,
  ...logging,
};
