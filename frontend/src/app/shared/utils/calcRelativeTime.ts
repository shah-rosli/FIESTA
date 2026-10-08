import { DateTime } from "luxon"

export const calcRelativeTime = (datestring: string) => {
  if (!datestring) {
    return "-"
  }
  let end = DateTime.fromISO(datestring, { zone: "utc" })
  if (!end.isValid) {
    throw new Error("Invalid date")
  }

  let start = DateTime.now().setZone("UTC")
  let diff = start.diff(end)

  const minutes = Math.floor(diff.as("minutes"))
  const hours = Math.floor(diff.as("hours"))
  const days = Math.floor(diff.as("days"))

  if (days > 0) {
    return `${days} day${days > 1 ? "s" : ""} ago`
  } else if (hours > 0) {
    return `${hours} hour${hours > 1 ? "s" : ""} ago`
  } else if (minutes > 0) {
    return `${minutes} min${minutes > 1 ? "s" : ""} ago`
  } else {
    return "just now"
  }
}