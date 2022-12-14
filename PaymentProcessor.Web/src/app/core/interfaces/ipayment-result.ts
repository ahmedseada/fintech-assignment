export interface IPaymentResult {
  responseCode: number,
  message: string,
  approvalCode: number,
  dateTime: number,
  done: boolean
}
