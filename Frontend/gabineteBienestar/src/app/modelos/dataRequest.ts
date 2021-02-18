import { PaginationResult } from "./pagedResult";
import {Parameters} from '../modelos/Parameters';

export class DataRequest{
  pagination?: PaginationResult;
  data : Array<Parameters> = [];
}
